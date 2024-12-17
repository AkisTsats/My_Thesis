using AnnouncementAPI.Helpers;
using AnnouncementAPI.Services;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ChannelWrapper _producer;
        private readonly AnnouncementService _announcementService;
        public PublicController(MyDbContext? context, ChannelWrapper? producer, AnnouncementService announcementService)
        {
            _context = context;
            _producer = producer;
            _announcementService = announcementService;
        }


        [HttpGet("GetFilteringSettings")]
        public async Task<ActionResult<DTOs.API.Public.GetFilteringSettings.Response>> GetFilteringSettings()
        {
            var categories = await _context.Categories.ToListAsync();
            var subjects = await _context.Subjects.ToListAsync();
            var academicYears = await _context.AcademicYears.ToListAsync();

            return Ok(new DTOs.API.Public.GetFilteringSettings.Response
            {
                Categories = categories.Select(e => e.ToCategoryDTO()),
                Subjects = subjects.Select(e => e.ToSubjectDTO()),
                //AcademicYears = academicYears.Select(e => e.ToAcademicYearDTO())
            });
        }

        [HttpPost("GetAnnouncements")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncements.Response>> GetAnnouncements([FromBody] DTOs.API.Public.GetAnnouncements.Request request)
        {
            var query = _announcementService.GetAnnouncementsQuery(
                request.TextContains,
                request.InCategoriesIds,
                request.InSubjectIds,
                request.OrderByCreationDateAscending,
                request.OrderByCreationDateDescending,
                includesForMapping: true
                );

            var count = await query.CountAsync();

            query = query.Skip(request.Skip).Take(request.Limit);

            var toRet =
                await query
                    .Select(e => e.ToAnnouncementDTO())
                    .ToListAsync();

            return Ok(new DTOs.API.Public.GetAnnouncements.Response()
            {
                Announcements = toRet,
                TotalCount = count
            });
        }

        [HttpPost("GetAnnouncement")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncement.Response>> GetAnnouncement([FromBody] DTOs.API.Public.GetAnnouncement.Request request)
        {
            var announcement =
                await _context.Announcements
                    .Include(e => e.Creator)
                    .Include(e => e.RelatedToSubjects)
                    .Include(e => e.RelatedToCategories)
                    .Where(e => e.Id == request.Id) 
                    .Select(e => e.ToAnnouncementDTO())
                    .FirstOrDefaultAsync();

            if (announcement is null)
                return NotFound("Announcement not found");

            return Ok(new DTOs.API.Public.GetAnnouncement.Response
            {
                Announcement = announcement
            });
        }


    }

}
