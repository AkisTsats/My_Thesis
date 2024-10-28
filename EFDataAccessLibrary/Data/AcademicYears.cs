using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDataAccessLibrary.Data
{
    public class AcademicYears
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }

        public ICollection<Announcement> RelatesToAnnouncements { get; set; }
        public ICollection<User> SelectedByUsers { get; set; }
    }
}
