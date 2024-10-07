using System.Net.NetworkInformation;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DTOs.Data;
using static DTOs.Common.Helpers;
using DTOs.API.Responses;
using static System.Net.WebRequestMethods;
using System;
using DTOs.API.Requests;

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

    }
}
