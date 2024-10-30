using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using EFDataAccessLibrary.Data;
using AnnouncementAPI.Helpers;
using AnnouncementAPI.Services;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Resources : ControllerBase
    {
        private readonly MyDbContext _context;

        public Resources(MyDbContext? context)
        {
            _context = context;

        }

        [HttpGet("GetResource")]
        public async Task<IActionResult> GetResource([FromQuery] int id)
        {
            var resource = await _context.Resources.FindAsync(id);

            if (resource is null)
                return NotFound();

            string baseDir = AppContext.BaseDirectory;
            var fullPath = Path.Combine(baseDir, "Files", resource.Name);

            var memory = new MemoryStream();

            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, resource.ContentType, resource.Name);
        }
    }
}
