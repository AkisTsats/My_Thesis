using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string? ContentType { get; set; } 
        public string? Path { get; set; }
        public bool? IsPrimaryImage { get; set; }
        public Announcement Announcement { get; set; }

    }
}
