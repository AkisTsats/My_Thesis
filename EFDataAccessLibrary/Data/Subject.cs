using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Subject
    {
        [Key]
        public int UserID { get; set; }
        public List<int> Subjects { get; set; }
    }
}
