using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common
{
    public class UploadResult
    {
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? Path { get; set; }
        public bool? IsPrimaryImage { get; set; }
    }
}
