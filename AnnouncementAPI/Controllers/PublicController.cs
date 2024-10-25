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

        // GET: api/ | get all announcements
        [HttpGet("GetAnnouncements")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncements.Response>> GetAnnouncements([FromQuery] DTOs.API.Public.GetAnnouncements.Request request)
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
                    .Select(e => AnnouncementMapper(e))
                    .ToListAsync();

            return Ok(new DTOs.API.Public.GetAnnouncements.Response()
            {
                Announcements = toRet,
                TotalCount = count
            });
        }

        //GET api/{object} get announcement by any type
        [HttpGet("GetAnnouncement/")]
        public async Task<ActionResult<DTOs.API.Public.GetAnnouncements.Response>> GetAnnouncement(int id)
        {
            var announcement =
                await _context.Announcements
                    .Where(e => e.Id == id)
                    .Select(e => AnnouncementMapper(e))
                    .FirstOrDefaultAsync();

            if (announcement is null)
                return NotFound("Announcement not found");

            return Ok(new DTOs.API.Public.GetAnnouncement.Response
            {
                Announcement = announcement
            });
        }

        private static AnnouncementDTO AnnouncementMapper(Announcement entry) => new()
        {
            AnnID = entry.Id,
            Title = entry.Title,
            Abstract = entry.Abstract,
            Body = entry.Body,
            Date = entry.CreationDate,
        };
    }

}
