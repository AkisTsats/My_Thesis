using System.Linq;
using System.Threading.Tasks;
using DTOs.API.Requests;
using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController(
        MyDbContext _context
        ) : ControllerBase
    {

        [HttpGet("GetSettingsForAnnouncementCreation")]
        public async Task<ActionResult<SettingsForAnnouncementCreation>> GetSettingsForAnnouncementCreation()
        {
            var categories = await _context.CList
                .Select(a => new CategoriesDTO(
                    a.CategoryID,
                    a.CategoryName
                    ))
                .ToListAsync();

            var subjects = await _context.SList
                .Select(a => new SubjectsDTO
                {
                    SubjectID = a.SubjectID,
                    SubjectName = a.SubjectName,
                })
                .ToListAsync();

            return Ok(new SettingsForAnnouncementCreation
            {
                Categories = categories,
                Subjects = subjects
            });
        }

    }
}
