using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common
{
    public class ResourceDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? ContentDisposition { get; set; }
        public bool isImage => ContentType?.StartsWith("image") ?? false;
    }
}
