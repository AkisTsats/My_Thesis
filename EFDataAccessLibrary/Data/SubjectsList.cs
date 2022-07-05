using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class SubjectsList
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public List<User> Users { get; set; }
    }
}
