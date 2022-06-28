using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class AnnouncementDTO
    {
        public int? AnnID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Body { get; set; }
        public DateTime? Date { get; set; }
        public bool? Alert { get; set; }
        public string? Author { get; set; }
        public List<SubjectsDTO>? Subjects { get; set; }
    }

}
