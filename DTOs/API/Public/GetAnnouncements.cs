using DTOs.Data;

namespace DTOs.API.Public.GetAnnouncements
{
    public class Request
    {
        public string? TextContains { get; set; } = null;
        public IEnumerable<int>? InCategoriesIds { get; set; } = null;
        public IEnumerable<int>? InSubjectIds { get; set; } = null;
        public bool OrderByCreationDateDescending { get; set; } = true;
        public bool OrderByCreationDateAscending { get; set; } = false;
        public int Limit { get; set; } = 100;
        public int Skip { get; set; } = 0;
    }

    public class Response
    {
        public IEnumerable<AnnouncementDTO> Announcements { get; set; }
        public int TotalCount { get; set; }
    }
}
