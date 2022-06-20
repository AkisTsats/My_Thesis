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
                AnnId = 1,
                Title = "Security issues and their solution",
                Abstract = "In the modern world of Reading practice to help you understand simple texts and find specific information in everyday material. Texts include emails, invitations, personal messages, tips, notices and signs.Reading practice to help you understand simple texts and find specific information",
                Body = "troll",
                Author = "Terezakis",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                AnnId = 2,
                Title = "Social hour",
                Abstract = "Reading practice to help you understand texts with everyday or job-related language. Texts include articles, travel guides, emails, adverts and reviews.Reading practice to help you understand texts with everyday or job-related language. Texts include articles, travel guides, emails, adverts and reviews.",
                Body = "test",
                Author= "Doe",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                AnnId = 3,
                Title = "Παρουσίαση Διπλωματικής",
                Abstract = "Reading practice to help you understand long, complex texts about a wide variety of topics, some of which may be unfamiliar. Texts include specialised articles, biographies and summaries.Reading practice to help you understand long, complex texts about a wide variety of topics, some of which may be unfamiliar. Texts include specialised articles, biographies and summaries.",
                Author = "Akis",
                Body = "test",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                AnnId = 4,
                Title = "Test",
                Abstract = "Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.",
                Body = "Test",
                Date = DateTime.Now,
                Alert = false
            },
            new(){
                AnnId = 5,
                Title = "Security issues and their solution",
                Abstract = "Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.Reading practice to help you understand simple information, words and sentences about known topics. Texts include posters, messages, forms and timetables.",
                Body = "troll",
                Author = "Terezakis",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                AnnId = 6,
                Title = "Social hour",
                Abstract = "Friday 4 o'clock at B3...",
                Body = "test",
                Author= "Doe",
                Date = DateTime.Now,
                Alert = false
            },
            new()
            {
                AnnId = 7,
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
        // POST: api/Announcement | post announcement
        [HttpPost("CreateAnnouncement")]
        public async Task<ActionResult<List<AnnouncementDTO>>> CreateAnnouncement([FromBody] AnnouncementDTO announcement)
        {
            //_context.Create(announcement);
            announcements.Add(announcement);
            //return Ok(announcements);
            return CreatedAtAction(nameof(announcements), new { id = announcement.AnnId }, announcement.AnnId);
        }
        
        [HttpPut]
        public async Task<ActionResult> Edit(int id, AnnouncementDTO ann)
        {
            var UserId = await this.User.GetIdByUser();

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

        // GET: api/ | get all announcements
        [HttpGet("GetAllAnnouncements")]
        public async Task<ActionResult<List<Announcement>>> Get()
        {
            return Ok(await _context.Announcements.ToListAsync());

        }

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





        //TODO make universal response object


        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Announcement>> GetById(int id)
        //{

        //    return await _context.Announcements
        //        .Where(a => a.AnnId == id)
        //        .Select(a => new Announcement
        //        {
        //            AnnId = a.AnnId,
        //            Abstract = a.Abstract,
        //            Alert = a.Alert,
        //            Body = a.Body,
        //            Date = a.Date,
        //            Repeats = a.Repeats,
        //            Title = a.Title,

        //        })
        //        .FirstOrDefaultAsync();
        //}


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void updateAnnouncement(int id, [FromBody] string value)
        {
        }








        //GET api/{object} get announcement by any type
        [HttpGet("GetAnnouncementByObj/")]
        public async Task<ActionResult<AnnouncementDTO>> GetAnnouncementByObj(int? id, string? title, DateTime? date)
        {
            //TODO validation

            AnnouncementDTO toReturn;
            var announcementsList = announcements.AsEnumerable();

            if (id is not null)
            {
                announcementsList = announcementsList.Where(a => a.AnnId == id);
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
                AnnId = a.AnnId,
                Abstract = a.Abstract,
                Alert = a.Alert,
                Body = a.Body,
                Date = a.Date,
                Title = a.Title,
            }).FirstOrDefault();

            return toReturn;

        }







        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<AnnouncementDTO>>> deleteAnnouncement(int id)
        //{
        //    var announcement = announcements.Find(a => a.AnnId == id);
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement not found");
        //    }
        //    announcements.Remove(announcement);
        //    return Ok(announcements);
        //}        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<AnnouncementDTO>>> deleteAnnouncement(int id)
        //{
        //    var announcement = announcements.Find(a => a.AnnId == id);
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement not found");
        //    }
        //    announcements.Remove(announcement);
        //    return Ok(announcements);
        //}

    }
}


