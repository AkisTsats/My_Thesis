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

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private static List<AnnouncementDTO> announcements = new()
        {
            new()
            {
                Title = "Security issues and their solution",
                Abstract = "In the modern world of Reading practice to help you understand simple texts and find specific information in everyday material. Texts include emails, invitations, personal messages, tips, notices and signs.Reading practice to help you understand simple texts and find specific information",
                Body = "troll",
                Author = "Terezakis",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                Title = "Social hour",
                Abstract = "Reading practice to help you understand texts with everyday or job-related language. Texts include articles, travel guides, emails, adverts and reviews.Reading practice to help you understand texts with everyday or job-related language. Texts include articles, travel guides, emails, adverts and reviews.",
                Body = "test",
                Author= "Doe",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                Title = "Παρουσίαση Διπλωματικής",
                Abstract = "Reading practice to help you understand long, complex texts about a wide variety of topics, some of which may be unfamiliar. Texts include specialised articles, biographies and summaries.Reading practice to help you understand long, complex texts about a wide variety of topics, some of which may be unfamiliar. Texts include specialised articles, biographies and summaries.",
                Author = "Akis",
                Body = "test",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                Title = "Test",
                Abstract = "Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.",
                Body = "Test",
                Date = DateTime.Now,
                Alert = false
            },
            new(){
                Title = "Security issues and their solution",
                Abstract = "Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.",
                Body = "troll",
                Author = "Terezakis",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                Title = "Social hour",
                Abstract = "Friday 4 o'clock at B3...",
                Body = "test",
                Author= "Doe",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                Title = "Παρουσίαση Διπλωματικής",
                Abstract = "Πέμπτη 5.30 θα πραγματοποιηθεί...",
                Author = "Akis",
                Body = "test",
                Date = DateTime.Now,
                Alert = false
            }


        };

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

        /*
        [HttpPut]
        public async Task<ActionResult> Edit(int id, AnnouncementDTO ann)
        {
            var UserID = await this.User.GetIdByUser();

            if (!dealerHasCar)
            {
                return BadRequest(Result.Failure("You cannot edit this ann"));
            }

            var category = await this.categories.Find(input.Category);

            var manufacturer = await this.manufacturers.FindByName(input.Manufacturer);

            manufacturer ??= new Manufacturer
            {
                Name = input.Manufacturer
            };

            var carAd = await this.carAds.Find(id);

            carAd.Manufacturer = manufacturer;
            carAd.Model = input.Model;
            carAd.Category = category;
            carAd.ImageUrl = input.ImageUrl;
            carAd.PricePerDay = input.PricePerDay;
            carAd.Options = new Options
            {
                HasClimateControl = input.HasClimateControl,
                NumberOfSeats = input.NumberOfSeats,
                TransmissionType = input.TransmissionType
            };

            await this.carAds.Save(carAd);

            return Result.Success;
        }
        */
        // GET: api/ | get announcement by parameter
        [HttpGet("GetAnnouncementBy")]
        public async Task<ActionResult<GetAnnouncementsByResponse>> getAnouncementBy()
        {
            return new GetAnnouncementsByResponse()
            {
                Announcements = announcements,
                SumOfAnnouncements = announcements.Count()

            };
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

            ann.AnnID = 0;
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






        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void updateAnnouncement(int id, [FromBody] string value)
        {
            
        }







        //[Authorize]
        //GET api/{object} get announcement by any type
        [HttpGet("GetAnnouncementByObj/")]
        public async Task<ActionResult<AnnouncementDTO>> GetAnnouncementByObj(int? id, string? title, DateTime? date)
        {
            //TODO validation
            AnnouncementDTO toReturn;

            var announcementsList = announcements.AsEnumerable();

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


            toReturn = announcementsList.Select(a => new AnnouncementDTO
            {
                AnnID = a.AnnID,
                Abstract = a.Abstract,
                Alert = a.Alert,
                Body = a.Body,
                Date = a.Date,
                Title = a.Title,
            }).FirstOrDefault();

            return toReturn;

        }


        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AnnouncementDTO>>> DeleteAnnouncement(int id)
        {
            if (id == null)
            {
                return BadRequest("Announcement not selected");
            }
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


