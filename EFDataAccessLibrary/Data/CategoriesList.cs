using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [InverseProperty(nameof(CategoriesListUser.Category))]
        public ICollection<CategoriesListUser> CategoriesListUsers { get; set; }


        [InverseProperty(nameof(CategoriesListAnnouncement.Category))]
        public ICollection<CategoriesListAnnouncement> CategoriesListAnnouncements { get; set; }
    }
}
