using DTOs.API.Requests;
using DTOs.Data;
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
        MyDbContext _context
        ) : ControllerBase
    {

        [HttpGet("GetSettingsForAnnouncementCreation")]
        public async Task<ActionResult<SettingsForAnnouncementCreation>> GetSettingsForAnnouncementCreation()
        {
            var categories = await _context.Categories
                .Select(a => new CategoriesDTO(
                    a.Id,
                    a.Name
                    ))
                .ToListAsync();

            var subjects = await _context.Subjects
                .Select(a => new SubjectsDTO(
                    a.Id,
                    a.Name
                    ))
                .ToListAsync();

            return Ok(new SettingsForAnnouncementCreation
            {
                Categories = categories,
                Subjects = subjects
            });
        }

    }
}
