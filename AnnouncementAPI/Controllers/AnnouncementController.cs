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
using AnnouncementAPI.Helpers;
using System.Threading.Channels;

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
        private readonly ProducerOfMyObjectsEndpoint _producer;

        public AnnouncementController(MyDbContext? context, ProducerOfMyObjectsEndpoint? producer)
        {
            _context = context;
            _producer = producer;
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
            var ann = new Announcement
            {
                Abstract = body.Abstract,
                Title = body.Title,
                Body = body.Body,
                Alert = body.Alert,
                Date = body.Date,
                Author = body.Author,
                //Files = body.Files.Select(f => new File
                //{
                //    FileName = f.FileName,
                //    ContentType = f.ContentType,
                //    Path = f.Path,
                //    IsPrimaryImage = f.IsPrimaryImage
                //}).ToList(),
            };

            foreach (var file in body.Files)
            {
                var newFile = new File
                {
                    Announcement = ann,
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Path = file.Path,
                    IsPrimaryImage = true //.IsPrimaryImage;
                };
                await _context.Files.AddAsync(newFile);
            }

            await _context.Announcements.AddAsync(ann);
            
            await _context.SaveChangesAsync();

            //await _producer.myEndpoint(body);


            //_context.Announcements.Add(ann);
            return Ok();
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
                    announcement.Abstract = body.Abstract;
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
        public async Task<ActionResult<GetAnnouncementsByResponse>> GetAnnouncementByObj(int? id, string? title, DateTime? date, string? category, int? limit, int? skip)
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

            if (category is not null)
            {
                var categoryId = _context.CList.Where(a => a.CategoryName == category).Select(b => b.CategoryID).First();

                var filteredAnnouncementsList = _context.categoriesListannouncement
                    .Where(a => a.CategoryID == categoryId).Select(b => b.Announcement);

                var filteredList = filteredAnnouncementsList.Select(a => new AnnouncementDTO()
                {
                    AnnID = a.AnnID,
                    Abstract = a.Abstract,
                    Alert = a.Alert,
                    Body = a.Body,
                    Date = a.Date,
                    Title = a.Title,
                }).ToListAsync();

                var filteredRet = new GetAnnouncementsByResponse
                {
                    Announcements = await filteredList,
                    SumOfAnnouncements = count,
                };
                return filteredRet;
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


