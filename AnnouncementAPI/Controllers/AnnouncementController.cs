using AnnouncementAPI.Helpers;
using AnnouncementAPI.Services;
using DTOs.API.Responses;
using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ProducerOfMyObjectsEndpoint _producer;
        private readonly AnnouncementService _announcementService;
        private readonly UserProvider _userProvider;

        public AnnouncementController(MyDbContext? context, ProducerOfMyObjectsEndpoint? producer, AnnouncementService announcementService, UserProvider userProvider)
        {
            _context = context;
            _producer = producer;
            _announcementService = announcementService;
            _userProvider = userProvider;
        }

        [HttpPost("GetAnnouncementsCreatedByMe")]
        public async Task<ActionResult<DTOs.API.Announcements.GetAnnouncementsCreatedByMe.Response>> GetAnnouncementsCreatedByMe([FromBody] DTOs.API.Announcements.GetAnnouncementsCreatedByMe.Request request)
        {
            var user = await _userProvider.GetUser();

            var query = _announcementService.GetAnnouncementsQuery(
                request.TextContains,
                request.InCategoriesIds,
                request.InSubjectIds,
                request.OrderByCreationDateAscending,
                request.OrderByCreationDateDescending,
                includesForMapping: true,
                allowUnpublished: true
                );

            query = query.Where(a => a.Creator.Id == user.Id);

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

        [HttpPost("GetAnnouncementsForMe")]
        public async Task<ActionResult<DTOs.API.Announcements.GetAnnouncementsForMe.Response>> GetAnnouncementsForMe([FromBody] DTOs.API.Announcements.GetAnnouncementsForMe.Request request)
        {
            var user = await _userProvider.GetUser(includeSubjectsAndCategories: true);

            var announcementsIdsSelectedFromCategories = user.SelectedCategories.SelectMany(c => c.RelatesToAnnouncements.Select(a => a.Id)).ToList();
            var announcementsIdsSelectedFromSubjects = user.SelectedSubjects.SelectMany(c => c.RelatesToAnnouncements.Select(a => a.Id)).ToList();
            var announcementsIdsSelectedFromAcademicYears = user.SelectedAcademicYears.SelectMany(c => c.RelatesToAnnouncements.Select(a => a.Id)).ToList();

            var query = _announcementService.GetAnnouncementsQuery(
                request.TextContains,
                request.InCategoriesIds,
                request.InSubjectIds,
                request.OrderByCreationDateAscending,
                request.OrderByCreationDateDescending,
                includesForMapping: true
                );

            query = query
                .Where(a => announcementsIdsSelectedFromCategories.Contains(a.Id) || announcementsIdsSelectedFromSubjects.Contains(a.Id))
                .Where(a => a.RelatesToAcademicYears.Count() == 0 || announcementsIdsSelectedFromAcademicYears.Contains(a.Id));

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

        // POST: api/CreateAnnouncement
        [HttpPost("CreateAnnouncement")]
        public async Task<ActionResult<AnnouncementDTO>> CreateAnnouncement(AnnouncementDTO body)
        {
            var ann = new Announcement
            {
                Abstract = body.Abstract,
                Title = body.Title,
                Body = body.Body,
                CreationDate = body.CreationDate,
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
                var newFile = new Resource
                {
                    //Announcement = ann,
                    //FileName = file.FileName,
                    //ContentType = file.ContentType,
                    //Path = file.Path,
                    //IsPrimaryImage = true //.IsPrimaryImage;
                };
                await _context.Resources.AddAsync(newFile);
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
                    announcement.CreationDate = body.CreationDate;

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
            throw new NotImplementedException();
            //var announcementsList = _context.Announcements.Where(_ => true);

            //if (id is not null)
            //{
            //    announcementsList = announcementsList.Where(a => a.Id == id);
            //}
            //if (title is not null)
            //{
            //    announcementsList = announcementsList.Where(a => a.Title.Contains(title));
            //}
            //if (date is not null)
            //{
            //    announcementsList = announcementsList.Where(a => a.CreationDate == date);
            //}

            //int count = announcementsList.Count();

            //if ((limit is not null) && (skip is not null))
            //{
            //    int s = skip.Value;
            //    int l = limit.Value;
            //    announcementsList = announcementsList.OrderBy(i => i.Id).Skip((s - 1) * l).Take(l);
            //}

            //if (category is not null)
            //{
            //    var categoryId = _context.Categories.Where(a => a.Name == category).Select(b => b.Id).First();

            //    var filteredAnnouncementsList = _context.Categories
            //        .Where(a => a.Id == categoryId).Select(b => b.);

            //    var filteredList = filteredAnnouncementsList.Select(a => new AnnouncementDTO()
            //    {
            //        AnnID = a.Id,
            //        Abstract = a.Abstract,
            //        Alert = a.Alert,
            //        Body = a.Body,
            //        Date = a.CreationDate,
            //        Title = a.Title,
            //    }).ToListAsync();

            //    var filteredRet = new GetAnnouncementsByResponse
            //    {
            //        Announcements = await filteredList,
            //        SumOfAnnouncements = count,
            //    };
            //    return filteredRet;
            //}

            //var listToReturn = announcementsList.Select(a => new AnnouncementDTO
            //{
            //    AnnID = a.Id,
            //    Abstract = a.Abstract,
            //    Alert = a.Alert,
            //    Body = a.Body,
            //    Date = a.CreationDate,
            //    Title = a.Title,
            //}).ToListAsync();

            //var toReturn = new GetAnnouncementsByResponse
            //{
            //    Announcements = await listToReturn,
            //    SumOfAnnouncements = count,
            //};
            //return toReturn;
        }



        // DELETE api/<controller>/5
        [HttpDelete("DeleteAnnouncementByID/{id}")]
        public async Task<ActionResult<List<AnnouncementDTO>>> DeleteAnnouncement(int id)
        {
            var announcement = await _context.Announcements.SingleOrDefaultAsync(a => a.Id == id);

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


