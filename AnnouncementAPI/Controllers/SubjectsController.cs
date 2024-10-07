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
using System.Text.Json.Serialization;
using FluentEmail.Core;
using DTOs.Common;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SubjectsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSubjects")]
        public async Task<ActionResult<List<SubjectsDTO>>> GetSubjects()
        {
            var subjects = await _context.SList
                .Select(s => new SubjectsDTO
                {
                    SubjectID = s.SubjectID,
                    SubjectName = s.SubjectName,
                })
                .ToListAsync();

            return Ok(subjects);
        }

        [HttpGet("GetSubjectsByID/{id}")]
        public async Task<ActionResult<List<SubjectsDTO>>> GetSubjectsByID(int id)
        {
            var subjects = await _context.subjectslistuser
                .Where(s => s.UserID == id)
                .SelectMany(slu => _context.SList.Where(s => s.SubjectID == slu.SubjectID))
                .Select(s => new SubjectsDTO
                {
                    SubjectID = s.SubjectID,
                    SubjectName = s.SubjectName,
                })
                .ToListAsync();

            return Ok(subjects);
        }

        [HttpPut("UpdateSubjects/{id}")]
        public async Task<ActionResult> UpdateSubjects(int id, IEnumerable<string> options)
        {
            if (options == null || !options.Any())
            {
                return BadRequest("Options cannot be null or empty.");
            }

            try
            {
                var newSubjectList = await _context.SList
                    .Where(s => options.Contains(s.SubjectName))
                    .ToListAsync();

                var oldSubjectList = await _context.subjectslistuser
                    .Where(slu => slu.UserID == id)
                    .ToListAsync();

                _context.subjectslistuser.RemoveRange(oldSubjectList);

                foreach (var subject in newSubjectList)
                {
                    var toAdd = new SubjectsListUser
                    {
                        SubjectID = subject.SubjectID,
                        UserID = id,
                    };
                    _context.Add(toAdd);
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}