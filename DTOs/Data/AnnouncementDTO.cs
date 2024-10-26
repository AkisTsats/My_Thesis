﻿using DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }  
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDTO Author { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; } = [];
        public IEnumerable<SubjectDTO> Subjects { get; set; } = [];

        public List<UploadResult> Files { get; set; } //TODO
    }

}
