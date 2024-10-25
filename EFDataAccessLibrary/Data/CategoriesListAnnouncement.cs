namespace EFDataAccessLibrary.Data
{
    public class CategoriesListAnnouncement
    {
        public int CategoryId { get; set; }

        public int AnnouncementID { get; set; }

        public Announcement Announcement { get; set; }

        public CategoriesList Category { get; set; }
    }
}
