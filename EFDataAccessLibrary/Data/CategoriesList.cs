using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class CategoriesList
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<User> Users { get; set; }
    }
}
