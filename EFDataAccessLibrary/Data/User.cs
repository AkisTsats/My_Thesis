using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public int EnrollmentYear { get; set; }
        public int CurrentYear { get; set; }
        public Preference Preferences { get; set; }
        public Permission Permissions { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public List<YearsList> YearsList { get; set; }
        public List<SubjectsList> SubjectsList { get; set; }
        public List<CategoriesList> CategoriesList { get; set; }

        [InverseProperty(nameof(CategoriesListUser.User))]
        public ICollection<CategoriesListUser> CategoriesListUsers { get; set; }





    }
}
