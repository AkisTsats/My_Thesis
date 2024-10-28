using DTOs.Common;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("UploadService")]
        public async Task<ActionResult<List<UploadResult>>> UploadService(List<IFormFile> files, [FromQuery] bool? isImage)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();
            try
            {
                if (files.Count != 0)
                {
                    foreach (var file in files)
                    {
                        var uploadResult = new UploadResult();
                        var fileName = file.FileName;

                        uploadResult.FileName = fileName;
                        var uploadpath = Path.Combine(_env.ContentRootPath, "Files", fileName);
                        uploadResult.ContentType = file.ContentType;
                        uploadResult.IsPrimaryImage = true;
                        uploadResult.Path = uploadpath;

                        var stream = new FileStream(uploadpath, FileMode.Create);
                        await file.CopyToAsync(stream);
                        uploadResults.Add(uploadResult);

                        return Ok(uploadResults);
                    }
                }
                return Ok("out");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
