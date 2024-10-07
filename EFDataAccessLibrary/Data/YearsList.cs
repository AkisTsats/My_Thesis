using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDataAccessLibrary.Data
{
    public class YearsList
    {
        [Key]
        public int YearID { get; set; }
        public int Year { get; set; }
        public List<User> Users { get; set; }
    }
}
