using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDTO>> GetUserController()
        {
            return await _context.Users
                .Where(u => u.UserId == 7)
                .Select(u => new UserDTO
                {
                    Name = u.Name
                }).FirstOrDefaultAsync();
        }
        
        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<UserDTO>> GetAllUsersController()
        {
            return await _context.Users
                .Where(u => u.UserId == 7)
                .Select(u => new UserDTO
                {
                    Name = u.Name
                }).FirstOrDefaultAsync();
        }
        

        // GET: api/ | get user by parameter
        [HttpGet("GetUserBy")]
        public IEnumerable<UserDTO> GetUserBy()
        {

            return _context.Users
                .Where(u => u.UserId == 7)
                .Select(u => new UserDTO
                {
                    Name = u.Name
                });
        }

        // GET: api/<controller>
        [HttpGet("GetUserRole")]
        public IEnumerable<string> GetUserRole()
        {
            return new string[] { "item1", "item2" };
        }

        // GET api/<controller>/5 | get user Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "item value";
        }


        // PUT api/<controller>/5 
        [HttpPut("{id}")]
        public void updateUser(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void deleteUser(int id)
        {
        }
    }
}
      