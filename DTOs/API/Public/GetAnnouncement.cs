using DTOs.Data;

namespace DTOs.API.Public.GetAnnouncement
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Response
    {
        public AnnouncementDTO Announcement { get; set; }
    }
}
