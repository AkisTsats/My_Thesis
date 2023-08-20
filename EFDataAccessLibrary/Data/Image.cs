using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string Path { get; set; }

        public Announcement Announcement { get; set; }
    }
}
