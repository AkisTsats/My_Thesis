using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class CategoriesListUser
    {
        
        public int CategoryID { get; set; }
        
        public int UserID { get; set; }

        public User User { get; set; }  

        public CategoriesList Category { get; set; }
    }
}
