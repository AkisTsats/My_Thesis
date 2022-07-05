using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class YearsList
    {
        [Key]
        public int YearsID { get; set; }
        public int Year { get; set; }
        public List<User> Users   { get; set; }
    }
}
