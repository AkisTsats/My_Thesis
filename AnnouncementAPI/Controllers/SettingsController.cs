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

        [HttpPost("GetMySettings")]
        public async Task<ActionResult<DTOs.API.Public.GetMySettings.Response>> GetMySettings()
        {
            var user = await _userProvider.GetUser(includeSubjectsAndCategories: true);

            return Ok(new DTOs.API.Public.GetMySettings.Response
            {
                Categories = user.SelectedCategories.Select(e => e.ToCategoryDTO()),
                Subjects = user.SelectedSubjects.Select(e => e.ToSubjectDTO()),
                AcademicYears = user.SelectedAcademicYears.Select(e => e.ToAcademicYearDTO())
            });
        }

        [HttpPost("UpdateMySettings")]
        public async Task<ActionResult<DTOs.API.Public.UpdateMySettings.Response>> UpdateMySettings([FromBody] DTOs.API.Public.UpdateMySettings.Request request)
        {
            var user = await _userProvider.GetUser(includeSubjectsAndCategories: true, tracking: true);

            var categories = await _context.Categories.Where(e => request.Categories.Select(e => e.Id).Contains(e.Id)).ToListAsync();
            var subjects = await _context.Subjects.Where(e => request.Subjects.Select(e => e.Id).Contains(e.Id)).ToListAsync();
            var academicYears = await _context.AcademicYears.Where(e => request.AcademicYears.Select(e => e.Id).Contains(e.Id)).ToListAsync();

            user.SelectedCategories = categories;
            user.SelectedSubjects = subjects;
            user.SelectedAcademicYears = academicYears;

            await _context.SaveChangesAsync();

            return Ok(new DTOs.API.Public.GetMySettings.Response
            {
                Categories = user.SelectedCategories.Select(e => e.ToCategoryDTO()),
                Subjects = user.SelectedSubjects.Select(e => e.ToSubjectDTO()),
                AcademicYears = user.SelectedAcademicYears.Select(e => e.ToAcademicYearDTO())
            });
        }
    }
}
