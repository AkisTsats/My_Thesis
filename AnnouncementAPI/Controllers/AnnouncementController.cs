using AnnouncementAPI.Helpers;
using AnnouncementAPI.Services;
using Common;
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
        public async Task<ActionResult<DTOs.API.Announcements.CreateAnnouncement.Response>> CreateAnnouncement([FromBody] DTOs.API.Announcements.CreateAnnouncement.Request request)
        {
            var user = await _userProvider.GetUser();

            Common.Common.RoleToPermissionMapping.TryGetValue(user.Role, out var permissions);

            if (!permissions.HasFlag(Permissions.ManageAnnouncements))
            {
                return Unauthorized();
            }

            var providedAnnouncement = request.Announcement;

            var categories = await _context.Categories.Where(c => providedAnnouncement.Categories.Select(e => e.Id).Contains(c.Id)).ToListAsync();
            var subjects = await _context.Subjects.Where(s => providedAnnouncement.Subjects.Select(e => e.Id).Contains(s.Id)).ToListAsync();
            var academicYears = await _context.AcademicYears.Where(ay => providedAnnouncement.AcademicYears.Select(e => e.Id).Contains(ay.Id)).ToListAsync();

            var announcement = new Announcement
            {
                CreatedTs = DateTime.UtcNow,
                Title = providedAnnouncement.Title,
                Abstract = providedAnnouncement.Abstract,
                Body = providedAnnouncement.Body,
                IsPublished = providedAnnouncement.IsPublished,
                Creator = user,

                //TODO resources

                RelatedToCategories = categories,
                RelatedToSubjects = subjects,
                RelatesToAcademicYears = academicYears,
            };

            await _context.AddAsync(announcement);

            await _context.SaveChangesAsync();

            return Ok(new DTOs.API.Announcements.CreateAnnouncement.Response()
            {
                Announcement = announcement.ToAnnouncementDTO()
            });
        }

        // PUT api/UpdateAnnouncement
        [HttpPut("UpdateAnnouncement")]
        public async Task<ActionResult<DTOs.API.Announcements.UpdateAnnouncement.Response>> UpdateAnnouncement([FromBody] DTOs.API.Announcements.UpdateAnnouncement.Request request)
        {
            var user = await _userProvider.GetUser();

            Common.Common.RoleToPermissionMapping.TryGetValue(user.Role, out var permissions);

            if (!permissions.HasFlag(Permissions.ManageAnnouncements))
                return Unauthorized();

            var existingAnnouncement = await _context.Announcements.AsTracking().SingleOrDefaultAsync(e => e.Id == request.Announcement.Id);

            if (existingAnnouncement is null)
                return NotFound();

            if (user.Id != existingAnnouncement.Creator.Id && !permissions.HasFlag(Permissions.Admin))
                return Unauthorized();

            var providedAnnouncement = request.Announcement;

            var categories = await _context.Categories.Where(c => providedAnnouncement.Categories.Select(e => e.Id).Contains(c.Id)).ToListAsync();
            var subjects = await _context.Subjects.Where(s => providedAnnouncement.Subjects.Select(e => e.Id).Contains(s.Id)).ToListAsync();
            var academicYears = await _context.AcademicYears.Where(ay => providedAnnouncement.AcademicYears.Select(e => e.Id).Contains(ay.Id)).ToListAsync();

            {
                existingAnnouncement.Title = providedAnnouncement.Title;
                existingAnnouncement.Abstract = providedAnnouncement.Abstract;
                existingAnnouncement.Body = providedAnnouncement.Body;
                existingAnnouncement.IsPublished = providedAnnouncement.IsPublished;

                existingAnnouncement.RelatedToCategories = categories;
                existingAnnouncement.RelatedToSubjects = subjects;
                existingAnnouncement.RelatesToAcademicYears = academicYears;
            }

            await _context.SaveChangesAsync();

            return Ok(new DTOs.API.Announcements.UpdateAnnouncement.Response()
            {
                Announcement = existingAnnouncement.ToAnnouncementDTO()
            });
        }

        // DELETE api/<controller>/5
        [HttpDelete("DeleteAnnouncementByID/{id}")]
        public async Task<ActionResult<AnnouncementDTO>> DeleteAnnouncement(int id)
        {
            var user = await _userProvider.GetUser();

            Common.Common.RoleToPermissionMapping.TryGetValue(user.Role, out var permissions);

            if (!permissions.HasFlag(Permissions.ManageAnnouncements))
                return Unauthorized();

            var existingAnnouncement = await _context.Announcements.AsTracking().SingleOrDefaultAsync(e => e.Id == request.Announcement.Id);

            if (existingAnnouncement is null)
                return NotFound();

            if (user.Id != existingAnnouncement.Creator.Id && !permissions.HasFlag(Permissions.Admin))
                return Unauthorized();

            _context.Announcements.Remove(existingAnnouncement);

            await _context.SaveChangesAsync();

            return Ok(existingAnnouncement);
        }
    }
}


