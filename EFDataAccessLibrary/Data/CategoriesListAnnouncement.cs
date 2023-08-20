using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class CategoriesListAnnouncement
    {
        public int CategoryID { get; set; }

        public int AnnouncementID { get; set; }

        public Announcement Announcement { get; set; }

        public CategoriesList Category { get; set; }
    }
}
