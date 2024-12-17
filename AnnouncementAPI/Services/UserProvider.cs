using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Services
{
    public class UserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MyDbContext _context;

        public UserProvider(IHttpContextAccessor httpContextAccessor, MyDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetUserEmail()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;

            return userEmail;
        }

        public async Task<User> GetUser(bool includeSubjectsAndCategories = false, bool tracking = false)
        {
            var query =
                _context.Users
                .Where(u => u.Email == GetUserEmail());

            if (!await query.AnyAsync())
            {
                var newUser = await UserAutoCreate();
            }

            if (includeSubjectsAndCategories)
            {
                query = query.Include(u => u.SelectedSubjects);
                query = query.Include(u => u.SelectedSubjects).ThenInclude(e => e.RelatesToAnnouncements);
                query = query.Include(u => u.SelectedCategories);
                query = query.Include(u => u.SelectedCategories).ThenInclude(e => e.RelatesToAnnouncements);
                query = query.Include(u => u.SelectedAcademicYears);
                query = query.Include(u => u.SelectedAcademicYears).ThenInclude(e => e.RelatesToAnnouncements);
            }

            if (tracking)
            {
                query = query.AsTracking();
            }

            return await query
                .FirstOrDefaultAsync();
        }

        public async Task<User> UserAutoCreate()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            var userFirstName = _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value;
            var userLastName = _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value;
            var userFullName = _httpContextAccessor.HttpContext.User.FindFirst("name").Value;
            var userRoles = _httpContextAccessor.HttpContext.User.FindAll("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/role");

            var userRole = userRoles.Any(e => e.Value == "personel") ? Common.UserRole.Staff : Common.UserRole.Student;

            var newUser = new User
            {
                Email = userEmail,
                FullName = userFullName,
                FirstName = userFirstName,
                LastName = userLastName,
                Role = userRole
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
