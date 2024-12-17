using DTOs.Common;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileUpload(MyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost("UploadService")]
        public async Task<ActionResult<List<ResourceDTO>>> UploadService(List<IFormFile> files, [FromQuery] bool isImage = false)
        {
            if (files.Count == 0)
                return Ok("out");

            var resources = new List<Resource>();

            foreach (var file in files)
            {
                var fileName = $"{RandomString(5)}_{file.FileName}";

                string baseDir = AppContext.BaseDirectory;

                var fullPath = Path.Combine(baseDir, "Files", fileName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);

                var resource = new Resource
                {
                    Name = fileName,
                    ContentType = file.ContentType,
                    FilePath = fullPath,
                    Type = isImage ? Common.ResourceType.Image : Common.ResourceType.Document,
                    ContentDisposition = file.ContentDisposition
                };

                _context.Add(resource);

                resources.Add(resource);
            }

            await _context.SaveChangesAsync();

            return resources.Select(r => new ResourceDTO
            {
                Id = r.Id,
                Url = $"https://localhost:5001/api/resources/getResource?id={r.Id}",
                FileName = r.Name,
                ContentType = r.ContentType,
                ContentDisposition = r.ContentDisposition,
            }).ToList();
        }
    }
}
