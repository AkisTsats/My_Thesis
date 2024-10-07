using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class SubjectsListAnnouncement
    {
        public int SubjectID { get; set; }

        public int AnnouncementID { get; set; }

        public Announcement Announcement { get; set; }

        public SubjectsList Subject { get; set; }
    }
}
