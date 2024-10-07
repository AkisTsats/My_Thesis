using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class FilesDTO
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
        public bool IsPrimaryImage { get; set; }
    }
}
