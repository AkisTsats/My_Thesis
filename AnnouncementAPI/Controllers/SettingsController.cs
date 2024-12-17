using AnnouncementAPI.Services;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController(
        MyDbContext _context,
        UserProvider _userProvider
        ) : ControllerBase
    {

        [HttpGet("GetMySettings")]
        public async Task<ActionResult<DTOs.API.Settings.GetMySettings.Response>> GetMySettings()
        {
            var user = await _userProvider.GetUser(includeSubjectsAndCategories: true);

            return Ok(new DTOs.API.Settings.GetMySettings.Response
            {
                PauseNotificationUntilDate = user.PauseNotificationsUntil,
                ReceiveNotificationsByEmail = user.NotificationSettingsDeserialized?.NotifyByEmail ?? false,
                ReceiveNotificationsInEmails = user.NotificationSettingsDeserialized?.NotifyEmails ?? [],
                ReceiveNotificationsByPhone = user.NotificationSettingsDeserialized?.NotifyByPhone ?? false,
                ReceiveNotificationsInPhones = user.NotificationSettingsDeserialized?.NotifyPhoneNumbers ?? [],
                Categories = user.SelectedCategories.Select(e => e.ToCategoryDTO()),
                Subjects = user.SelectedSubjects.Select(e => e.ToSubjectDTO()),
                //AcademicYears = user.SelectedAcademicYears.Select(e => e.ToAcademicYearDTO())
            });
        }

        [HttpPost("UpdateMySettings")]
        public async Task<ActionResult<DTOs.API.Settings.UpdateMySettings.Response>> UpdateMySettings([FromBody] DTOs.API.Settings.UpdateMySettings.Request request)
        {
            var user = await _userProvider.GetUser(includeSubjectsAndCategories: true, tracking: true);

            var categories = await _context.Categories.Where(e => request.Categories.Select(e => e.Id).Contains(e.Id)).ToListAsync();
            var subjects = await _context.Subjects.Where(e => request.Subjects.Select(e => e.Id).Contains(e.Id)).ToListAsync();
            var academicYears = await _context.AcademicYears.Where(e => request.AcademicYears.Select(e => e.Id).Contains(e.Id)).ToListAsync();

            user.SelectedCategories = categories;
            user.SelectedSubjects = subjects;
            user.SelectedAcademicYears = academicYears;

            var notificationSettings = user.NotificationSettingsDeserialized;
            notificationSettings = notificationSettings with
            {
                NotifyByPhone = request.ReceiveNotificationsByPhone,
                NotifyByEmail = request.ReceiveNotificationsByEmail,
                NotifyPhoneNumbers = request.ReceiveNotificationsInPhones,
                NotifyEmails = request.ReceiveNotificationsInEmails
            };
            user.NotificationSettingsDeserialized = notificationSettings;

            user.PauseNotificationsUntil = request.PauseNotificationUntilDate;

            await _context.SaveChangesAsync();

            return Ok(new DTOs.API.Settings.GetMySettings.Response
            {
                PauseNotificationUntilDate = user.PauseNotificationsUntil,
                ReceiveNotificationsByEmail = user.NotificationSettingsDeserialized.NotifyByEmail,
                ReceiveNotificationsInEmails = user.NotificationSettingsDeserialized.NotifyEmails,
                ReceiveNotificationsByPhone = user.NotificationSettingsDeserialized.NotifyByPhone,
                ReceiveNotificationsInPhones = user.NotificationSettingsDeserialized.NotifyPhoneNumbers,
                Categories = user.SelectedCategories.Select(e => e.ToCategoryDTO()),
                Subjects = user.SelectedSubjects.Select(e => e.ToSubjectDTO()),
                //AcademicYears = user.SelectedAcademicYears.Select(e => e.ToAcademicYearDTO())
            });
        }
    }
}
