using DTOs.API.Responses;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.Data;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace AnnouncementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {


        private static StatisticsDTO Statistics = new()
        {
            TodayAnnouncements = 1,
            TodayPeakUsers = 12,
            TotalAnnouncements = 430,
            TotalUsers = 500
        };

        private readonly MyDbContext _context;

        public AnnouncementController(MyDbContext context)
        {
            _context = context;
        }


        // GET: api/ | get all announcements
        [HttpGet("GetAllAnnouncements")]
        public async Task<ActionResult<List<Announcement>>> Get()
        {
            return Ok(await _context.Announcements.ToListAsync());

        }

        // GET: api/ | get announcement by parameter
        [HttpGet("GetStats")]
        public async Task<ActionResult<StatisticsDTO>> getStats()
        {
            return new StatisticsDTO()
            {
                TodayAnnouncements = 1,
                TodayPeakUsers = 12,
                TotalAnnouncements = 430,
                TotalUsers = 500
            };
        }

        // POST: api/CreateAnnouncement
        [HttpPost("CreateAnnouncement")]
        public async Task<ActionResult<AnnouncementDTO>> CreateAnnouncement(AnnouncementDTO body)
        {
            Announcement ann = new Announcement();

            ann.AnnID = new();
            ann.Abstract = body.Abstract;
            ann.Title = body.Title;
            ann.Body = body.Body;
            ann.Alert = body.Alert;
            ann.Date = body.Date;
            ann.Author = body.Author;
            await _context.Announcements.AddAsync(ann);
            await _context.SaveChangesAsync();


            //_context.Announcements.Add(ann);
            return Ok(_context.Announcements);
        }


        // PUT api/UpdateAnnouncement
        [HttpPut("UpdateAnnouncementByID/{id}")]
        public async Task<ActionResult<AnnouncementDTO>> UpdateAnnouncement(int id, AnnouncementDTO? body)
        {
            var announcement = await _context.Announcements.FindAsync(id);

            if (announcement == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    //_context.Announcements.Remove(announcement.Title);
                    announcement.Title = body.Title;
                    announcement.Abstract= body.Abstract;
                    announcement.Body = body.Body;
                    announcement.Date = body.Date;
                    announcement.Author = body.Author;

                    //_context.Announcements.Update(announcement);

                    await _context.SaveChangesAsync();
                    return NoContent(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured {ex}"); 
                    return BadRequest(ex.Message);
                }
                
            }
        }



        //GET api/{object} get announcement by any type
        [HttpGet("GetAnnouncementByObj/")]
        public async Task<ActionResult<GetAnnouncementsByResponse>> GetAnnouncementByObj(int? id, string? title, DateTime? date, int? limit, int? skip)
        {
            //TODO validation

            var announcementsList = _context.Announcements.Where(_ => true);

            if (id is not null)
            {
                announcementsList = announcementsList.Where(a => a.AnnID == id);
            }
            if (title is not null)
            {
                announcementsList = announcementsList.Where(a => a.Title.Contains(title));
            }
            if (date is not null)
            {
                announcementsList = announcementsList.Where(a => a.Date == date);
            }

            int count = announcementsList.Count();

            if ((limit is not null) && (skip is not null))
            {
                int s = skip.Value;
                int l = limit.Value;
                announcementsList = announcementsList.OrderBy(i => i.AnnID).Skip((s - 1) * l).Take(l);
            }


            var listToReturn = announcementsList.Select(a => new AnnouncementDTO
            {
                AnnID = a.AnnID,
                Abstract = a.Abstract,
                Alert = a.Alert,
                Body = a.Body,
                Date = a.Date,
                Title = a.Title,
            }).ToListAsync();

            var toReturn = new GetAnnouncementsByResponse
            {
                Announcements = await listToReturn,
                SumOfAnnouncements = count,
            };

            return toReturn;

        }


        // DELETE api/<controller>/5
        [HttpDelete("DeleteAnnouncementByID/{id}")]
        public async Task<ActionResult<List<AnnouncementDTO>>> DeleteAnnouncement(int id)
        {
            var announcement = await _context.Announcements.SingleOrDefaultAsync(a => a.AnnID == id);

            if (announcement == null)
            {
                return BadRequest("Announcement not found");
            }

            _context.Announcements.Remove(announcement);

            await _context.SaveChangesAsync();

            return Ok(_context.Announcements);


        }
    }
}


