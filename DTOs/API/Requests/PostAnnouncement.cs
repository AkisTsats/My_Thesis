using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Data;


namespace DTOs.API.Requests
{
    public class PostAnnouncement
    {
        public AnnouncementDTO Announcements { get; set; }

        public int UserID { get; set; }

    }
}
