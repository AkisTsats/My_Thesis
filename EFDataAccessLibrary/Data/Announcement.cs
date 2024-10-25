using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Announcement
    {
        [Key]
        public int AnnID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Alert { get; set; }
        public string Author { get; set; }        
        public User User { get; set; }
        public List<File>? Files { get; set; }
        public List<CategoriesList> CategoriesList { get; set; }
        public List<SubjectsList> SubjectsList { get; set; }

        [InverseProperty(nameof(CategoriesListAnnouncement.Announcement))]
        public ICollection<CategoriesListAnnouncement> CategoriesListAnnouncements { get; set; }

        [InverseProperty(nameof(SubjectsListAnnouncement.Announcement))]
        public ICollection<SubjectsListAnnouncement> SubjectsListAnnouncements { get; set; }

    }

}
