using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class FileUploadDTO
    {
        public MultipartFormDataContent MultipartFormDataContent { get; set; }
        public bool isImage { get; set; }
    }
}
