using DTOs.Data;
using static DTOs.Common.Helpers;

namespace CeidAnnouncementManager.Services
{
    public class AnnouncementsRepository
    {

        private readonly HttpClient http;

        public AnnouncementsRepository(HttpClient Http)
        {
            http = Http;
        }

        const string BaseUrl = "https://localhost:5001";


        public async Task<IEnumerable<AnnouncementDTO>> FetchMultiple()
        {
            var response = await http.GetStringAsync(BaseUrl + "/api/Public/GetAnnouncements");

            var deserialized = response.DeserializeMethod<List<AnnouncementDTO>>();

            return deserialized;
        }

        public async Task<AnnouncementDTO> FetchSingle(int id)
        {
            var response = await http.GetStringAsync(BaseUrl + $"/api/Public/GetAnnouncement/{id}");

            var deserialized = response.DeserializeMethod<AnnouncementDTO>();

            return deserialized;

        }
    }
}
