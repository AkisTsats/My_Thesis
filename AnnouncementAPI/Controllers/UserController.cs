using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                .Where(u => u.UserID == 7)
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
                .Where(u => u.UserID == 7)
                .Select(u => new UserDTO
                {
                    Name = u.Name
                }).FirstOrDefaultAsync();
        }


        // GET: api/ | get user by parameter
        [HttpGet("GetUserBy")]
        public async Task<ActionResult<UserDTO>> GetUserBy(int? id, string? email)
        {
            var userToRet = _context.Users.Where(_ => true);

            if (id is not null)
            {
                userToRet = userToRet.Where(u => u.UserID == id);
            }

            if (email is not null)
            {
                userToRet = userToRet.Where(u => u.PrimaryEmail == email);

            }

            var toRet = await userToRet.Select(u => new UserDTO
            {
                UserID = u.UserID,
                Name = u.Name,
                Surname = u.Surname,
                PrimaryEmail = u.PrimaryEmail
                //CurrentYear = u.CurrentYear,
                //SecondaryEmail = u.SecondaryEmail,
                //EnrollmentYear = u.EnrollmentYear,
                //PhoneNumber = u.PhoneNumber,
                //PrimaryEmail = u.PrimaryEmail,
                //Role = u.Role
            }).FirstOrDefaultAsync();


            return toRet;
        }

        // PUT api/User/UpdateUserByID/id 
        [HttpPut("UpdateUserByID/{id}")]
        public async Task<ActionResult<UserDTO>> updateUser(int id, UserDTO? body)
        {
            var user = await _context.Users.Where(a => a.UserID == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    user.CurrentYear = body.CurrentYear;
                    user.PhoneNumber = body.PhoneNumber;
                    user.PrimaryEmail = body.PrimaryEmail;
                    user.SecondaryEmail = body.SecondaryEmail;

                    await _context.SaveChangesAsync();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured {ex}");
                    return BadRequest(ex.Message);
                }
            }
        }


        // DELETE api/User/DeleteUser
        [HttpDelete("DeleteUserByID{id}")]
        public void deleteUser(int id)
        {
        }
    }
}
