using AnnouncementAPI.Helpers;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
#if DEBUG

    [Route("api/[controller]")]
    [ApiController]
    public class Admin : ControllerBase
    {
        private readonly MyDbContext _context;

        public Admin(MyDbContext? context)
        {
            _context = context;
        }

        [HttpPost("PopulateDatabase")]
        public async Task<ActionResult<bool>> PopulateDatabase()
        {
            var toAdd = new List<object>();

            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                FullName = "Admin Admin",
                Email = "admin@admin.admin",
            };
            toAdd.Add(admin);

            var simpleUser = new User
            {
                FirstName = "Simple",
                LastName = "User",
                FullName = "Simple User",
                Email = "simple@user.user",
            };
            toAdd.Add(simpleUser);

            var category1 = new Category
            {
                Name = "Category1",
            };
            toAdd.Add(category1);

            var category2 = new Category
            {
                Name = "Category2",
            };
            toAdd.Add(category2);

            var subject1 = new Subject
            {
                Name = "Subject1",
            };
            toAdd.Add(subject1);

            var subject2 = new Subject
            {
                Name = "Subject2",
            };
            toAdd.Add(subject2);

            var announcement1 = new Announcement
            {
                Title = "Announcement1",
                Body = "Body1",
                CreationDate = System.DateTime.Now,
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Abstract1",
                Creator = admin,
            };
            toAdd.Add(announcement1);

            foreach (var item in toAdd)
            {
                _context.Add(item);
            }

            await _context.SaveChangesAsync();

            return true;
        }
    }

#endif
}
