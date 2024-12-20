﻿using DTOs.Data;
using System.Text;
using static DTOs.Common.Helpers;

namespace CeidAnnouncementManager.Services
{
    public class PublicRepository
    {

        private readonly HttpClient http = new();

        public PublicRepository()
        { }

        const string BaseUrl = "https://localhost:5001";

        public async Task<DTOs.API.Public.GetFilteringSettings.Response> FetchFilteringSettings()
        {
            var response = await http.GetStringAsync(BaseUrl + "/api/Public/GetFilteringSettings");

            var responseDeserialized = response.DeserializeMethod<DTOs.API.Public.GetFilteringSettings.Response>();

            return responseDeserialized;
        }

        public async Task<DTOs.API.Public.GetAnnouncements.Response> FetchMultiple(DTOs.API.Public.GetAnnouncements.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Public/GetAnnouncements", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Public.GetAnnouncements.Response>();

            return responseDeserialized;
        }

        public async Task<DTOs.API.Public.GetAnnouncement.Response> FetchSingle(DTOs.API.Public.GetAnnouncement.Request request)
        {
            var requestJson = request.SerializeMethod();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Public/GetAnnouncement", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseDeserialized = responseString.DeserializeMethod<DTOs.API.Public.GetAnnouncement.Response>();

            return responseDeserialized;
        }
    }
}
