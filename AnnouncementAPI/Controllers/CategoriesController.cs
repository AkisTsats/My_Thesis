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
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            throw new NotSupportedException();
            //var categories = await _context.CList
            //    .Select(a => new CategoriesDTO
            //    {
            //        CategoryID = a.CategoryID,
            //        CategoryName = a.CategoryName,
            //    })
            //    .ToListAsync();

            //return Ok(categories);
        }

        [HttpGet("GetCategoriesByID/{id}")]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategoriesByID(int id)
        {
            throw new NotSupportedException();
            //var categories = await _context.categorieslistuser
            //    .Where(a => a.UserID == id)
            //    .SelectMany(a => _context.CList.Where(c => c.CategoryID == a.CategoryID))
            //    .Select(a => new CategoriesDTO
            //    {
            //        CategoryID = a.CategoryID,
            //        CategoryName = a.CategoryName,
            //    })
            //    .ToListAsync();

            //return Ok(categories);
        }

        [HttpPut("UpdateCategories/{id}")]
        public async Task<ActionResult<List<CategoryDTO>>> UpdateCategories(int id, IEnumerable<string> options)
        {
            throw new NotSupportedException();
            //if (options == null || !options.Any())
            //{
            //    return BadRequest("Options cannot be null or empty.");
            //}

            //var newCategoryList = await _context.CList
            //    .Where(c => options.Contains(c.CategoryName))
            //    .ToListAsync();

            //var oldCategoryList = await _context.categorieslistuser
            //    .Where(a => a.UserID == id)
            //    .ToListAsync();

            //_context.categorieslistuser.RemoveRange(oldCategoryList);

            //foreach (var cat in newCategoryList)
            //{
            //    var toAdd = new CategoriesListUser
            //    {
            //        CategoryID = cat.CategoryID,
            //        UserID = id,
            //    };
            //    _context.Add(toAdd);
            //}

            //await _context.SaveChangesAsync();

            //return Ok();
        }
    }

}
