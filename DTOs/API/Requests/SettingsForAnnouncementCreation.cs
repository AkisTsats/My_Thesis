using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Data;

namespace DTOs.API.Requests
{
    public class SettingsForAnnouncementCreation
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        //public IEnumerable<GradesDTO> Grades { get; set; }
    }
}
