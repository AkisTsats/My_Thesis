using AnnouncementAPI.Services;
using Common;
using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        private UserProvider _userProvider;

        public UserController(MyDbContext context, UserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        // GET: api/<UserController>
        [HttpGet("GetMe")]
        public async Task<ActionResult<UserDTO>> GetMe()
        {
            var user = await _userProvider.GetUser();

            if (user is null)
                return NotFound();

            return user.ToUserDTO();
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var user = await _userProvider.GetUser();

            if (user is null)
                return NotFound();

            if (user.Role != UserRole.Admin)
                return Unauthorized();

            var users = await _context.Users
                .Select(u => u.ToUserDTO())
                .ToListAsync();

            return users;
        }

        // DELETE api/User/DeleteUser
        [HttpDelete("DeleteUserByID{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userProvider.GetUser();

            if (user is null)
                return NotFound();

            if (user.Role != UserRole.Admin)
                return Unauthorized();

            throw new NotImplementedException();
        }
    }
}
