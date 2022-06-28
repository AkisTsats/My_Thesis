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

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private Dictionary<int, string> categories = new()
        {
            {1, "test" },
            {6, "math" },
            {2, "math"},
            {3, "logikh"},
            {4, "fusikh"},
            {5, "algorithmoi"}
        };


        // GET: api/ | get announcement by parameter
        //[HttpGet("GetCategories")]
        //public async Task<ActionResult<List<string>>> GetCategories(int id)
        //{
        //    var row = array.GetValue(id);
        //    foreach (var user in array)
        //    {
        //        if 
                
        //    }
        //}
    }
}
