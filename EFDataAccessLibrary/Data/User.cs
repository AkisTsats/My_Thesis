using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<Announcement> Announcements { get; set; }
        //public virtual ICollection<Year> Years { get; set; }
        //public virtual ICollection<Subjects> Subjects { get; set; }

    }
}
