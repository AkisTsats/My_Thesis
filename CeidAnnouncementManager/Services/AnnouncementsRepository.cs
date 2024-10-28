using DTOs.Data;
using System.Text;
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

        public async Task<DTOs.API.Announcements.GetAnnouncementsCreatedByMe.Response> FetchCreatedByMe(DTOs.API.Announcements.GetAnnouncementsCreatedByMe.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Announcement/GetAnnouncementsCreatedByMe", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Announcements.GetAnnouncementsCreatedByMe.Response>();

            return responseDeserialized;
        }

        public async Task<DTOs.API.Announcements.GetAnnouncementsForMe.Response> FetchAnnouncementsForMe(DTOs.API.Announcements.GetAnnouncementsForMe.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Announcement/GetAnnouncementsForMe", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Announcements.GetAnnouncementsForMe.Response>();

            return responseDeserialized;
        }

        public async Task<DTOs.API.Public.GetAnnouncement.Response> FetchSingle(DTOs.API.Public.GetAnnouncement.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Announcement/GetAnnouncement", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Public.GetAnnouncement.Response>();

            return responseDeserialized;
        }
    }
}
