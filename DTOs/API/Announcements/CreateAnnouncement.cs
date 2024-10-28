using DTOs.Data;

namespace DTOs.API.Announcements.CreateAnnouncement
{
    public class Request
    {
        public AnnouncementDTO Announcement { get; set; }
    }

    public class Response
    {
        public AnnouncementDTO Announcement { get; set; }
    }
}
