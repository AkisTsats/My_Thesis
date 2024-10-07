using EFDataAccessLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class SubjectsList
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public List<User> Users { get; set; }
        [InverseProperty(nameof(SubjectsListUser.Subject))]
        public ICollection<SubjectsListUser> SubjectsListUsers { get; set; }

        public List<Announcement> Announcements { get; set; }

        [InverseProperty(nameof(SubjectsListAnnouncement.Subject))]
        public ICollection<SubjectsListAnnouncement> SubjectsListAnnouncements { get; set; }
    }
}



