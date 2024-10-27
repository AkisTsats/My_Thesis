using AnnouncementAPI.Helpers;
using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly ProducerOfMyObjectsEndpoint _producer;

        public PublicController(MyDbContext? context, ProducerOfMyObjectsEndpoint? producer)
        {
            _context = context;
            _producer = producer;
        }


        [HttpGet("GetFilteringSettings")]
        public async Task<ActionResult<DTOs.API.Public.GetFilteringSettings.Response>> GetFilteringSettings()
        {
            var categories = await _context.Categories.ToListAsync();
            var subjects = await _context.Subjects.ToListAsync();

            return Ok(new DTOs.API.Public.GetFilteringSettings.Response
            {
                Categories = categories.Select(e => e.ToCategoryDTO()),
                Subjects = subjects.Select(e => e.ToSubjectDTO())
            });
        }

        [HttpPost("GetAnnouncements")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncements.Response>> GetAnnouncements([FromBody] DTOs.API.Public.GetAnnouncements.Request request)
        {
            var query = _context.Announcements.AsQueryable();

            if (request.TextContains is not null)
            {
                query = query.Where(a => a.Title.Contains(request.TextContains) || a.Body.Contains(request.TextContains));
            }

            if (request.InCategoriesIds is not null)
            {
                query = query.Where(a => a.RelatedToCategories.Any(b => request.InCategoriesIds.Contains(b.Id)));
            }

            if (request.InSubjectIds is not null)
            {
                query = query.Where(a => a.RelatedToSubjects.Any(b => request.InSubjectIds.Contains(b.Id)));
            }

            if (request.OrderByCreationDateAscending)
            {
                query = query.OrderBy(a => a.CreationDate);
            }
            else if (request.OrderByCreationDateDescending)
            {
                query = query.OrderByDescending(a => a.CreationDate);
            }
            else
            {
                query = query.OrderBy(a => a.Id);
            }

            //query = query.Where(e => true); // filter non published, soft deleted etc

            var count = await query.CountAsync();

            query = query.Skip(request.Skip).Take(request.Limit);

            var toRet =
                await query
                    .Include(e => e.Creator)
                    .Select(e => e.ToAnnouncementDTO())
                    .ToListAsync();

            return Ok(new DTOs.API.Public.GetAnnouncements.Response()
            {
                Announcements = toRet,
                TotalCount = count
            });
        }

        [HttpPost("GetAnnouncement")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncement.Response>> GetAnnouncement([FromBody] DTOs.API.Public.GetAnnouncement.Request id)
        {
            var announcement =
                await _context.Announcements
                    .Include(e => e.Creator)
                    //.Where(e => e.Id == id) //TODO 
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
