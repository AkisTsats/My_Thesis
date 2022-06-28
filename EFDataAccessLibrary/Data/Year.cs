using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Year
    {
        [Key]
        public int UserID { get; set; }
        public List<int> Years { get; set; }
    }
}
