using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDataAccessLibrary.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Announcement> RelatesToAnnouncements { get; set; }
        public ICollection<User> SelectedByUsers { get; set; }
    }
}
