using DTOs.API.Requests;
using System.Text;
using static DTOs.Common.Helpers;
using static System.Net.WebRequestMethods;

namespace CeidAnnouncementManager.Services
{
    public class SettingsRepository
    {

        private readonly HttpClient _http;

        public SettingsRepository(HttpClient http)
        {
            _http = http;
        }

        const string BaseUrl = "https://localhost:5001"; //TODO move to appsettings.json


        public async Task<SettingsForAnnouncementCreation> FetchSettingsForCreateAnnouncement()
        {
            var response = await _http.GetStringAsync(BaseUrl + "/api/settings/GetSettingsForAnnouncementCreation");
            var deserializedResponse = response.DeserializeMethod<SettingsForAnnouncementCreation>();

            return deserializedResponse;
        }

        public async Task<DTOs.API.Settings.GetMySettings.Response> FetchMySettings() 
        {
            var response = await _http.GetStringAsync(BaseUrl + "/api/settings/getmysettings");

            var deserializedResponse = response.DeserializeMethod<DTOs.API.Settings.GetMySettings.Response>();

            return deserializedResponse;
        }

        public async Task<DTOs.API.Settings.UpdateMySettings.Response> UpdateMySettings(DTOs.API.Settings.UpdateMySettings.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(BaseUrl + "/api/settings/updateMySettings", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Settings.UpdateMySettings.Response>();

            return responseDeserialized;
        }

    }
}
