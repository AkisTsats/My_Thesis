using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Data;

namespace DTOs.API.Responses
{
    public class GetAnnouncementsByResponse
    {
        public IEnumerable<AnnouncementDTO> Announcements { get; set; }
        public int SumOfAnnouncements { get; set; }
    }



}
