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
using FluentEmail.Core;

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


        //GET: api/ | get all categories
        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<CategoriesDTO>>> GetCategories()
        {

            var toReturn = await _context.CList.Select(a => new CategoriesDTO
            {
                CategoryID = a.CategoryID,
                CategoryName = a.CategoryName,
            }).ToListAsync();



            return Ok(toReturn);

        }


        //GET: api/ | get categories by id
        [HttpGet("GetCategoriesByID/{id}")]
        public async Task<ActionResult<List<CategoriesDTO>>> GetCategoriesByID(int id)
        {
            var categories = await _context.categorieslistuser.Where(a => a.UserID == id).ToListAsync();

            var allCategoryID = categories.Select(a => a.CategoryID).ToList();

            var names = await _context.CList.Where(a => allCategoryID.Contains(a.CategoryID)).AsNoTracking().ToListAsync();

            var toRet = names.Select(a => new CategoriesDTO
            {
                CategoryID = a.CategoryID,
                CategoryName = a.CategoryName
            }).ToList();




            //var toReturn = await _context.CList.Where(b => b.CategoryID == categories.categoryID).ToListAsync();
            //var toReturn = await categories.Select(a => new CategoriesDTO
            //{
            //    CategoryID = a.CategoryID,
            //    CategoryName = a.CategoryName,
            //}).ToListAsync();



            return Ok(toRet);

        }

        // PUT api/UpdateAnnouncement
        [HttpPut("UpdateCategories/{id}")]
        public async Task<ActionResult<List<CategoriesDTO>>> UpdateCategories(int id, IEnumerable<string>? options)
        {
            List<CategoriesList> myList = new List<CategoriesList>();

            //var oldCategories = await GetCategoriesByID(id);
            foreach (var op in options)
            {
                var myvar = await _context.CList.Where(a => a.CategoryName == op).ToListAsync();
                myList.AddRange(myvar);


            }
            
            var categories = await _context.categorieslistuser.Where(a => a.UserID == id).ToListAsync();

            var oldCategoryID = categories.Select(a => a.CategoryID).ToList();

            foreach (var cat in oldCategoryID)
            {
                var toRemove = _context.categorieslistuser.FirstOrDefault(a => a.CategoryID == cat);
                _context.Remove(toRemove);
                
            }

            //var newCategoryID = newCategories.Select(a => a.CategoryID).ToList();

            foreach (var cat in myList)
            {
                CategoriesListUser toAdd = new();
                toAdd.CategoryID = cat.CategoryID;
                toAdd.UserID = id;
                _context.Add(toAdd);
                
            }

            await _context.SaveChangesAsync();


            return NoContent();


            //var names = await _context.CList.Where(a => allCategoryID.Contains(a.CategoryID)).AsNoTracking().ToListAsync();

            //var oldCategories = names.Select(a => new CategoriesDTO
            //{
            //    CategoryID = a.CategoryID,
            //    CategoryName = a.CategoryName
            //}).ToList();


            //if (oldCategories is null)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    try
            //    {
            //        var toDelete = newCategories.Where(a => !(oldCategories.Contains(a)));
            //        var toAdd = oldCategories.Where(b => !(newCategories.Contains(b)));



            //        foreach (var category in toDelete)
            //        {
            //           _context.Remove(category);
            //        }
            //        await _context.SaveChangesAsync();
            //        return NoContent();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error occured {ex}");
            //        return BadRequest(ex.Message);
            //    }

            //}
        }
    }
}
