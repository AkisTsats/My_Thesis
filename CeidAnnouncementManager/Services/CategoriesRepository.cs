﻿using System.Net.NetworkInformation;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DTOs.Data;
using static DTOs.Common.Helpers;
using DTOs.API.Responses;
using static System.Net.WebRequestMethods;
using System;

namespace CeidAnnouncementManager.Services
{
    public class CategoriesRepository
    {

        private readonly HttpClient http;

        public CategoriesRepository(HttpClient Http) {
            http= Http;
        }

        const string BaseUrl = "https://localhost:5001";


        public async Task<IEnumerable<CategoriesDTO>> FetchCategories()
        { 
            var response = await http.GetStringAsync(BaseUrl + "/api/Categories/GetCategories");
            var annResponse = response.DeserializeMethod<List<CategoriesDTO>>();

            return annResponse;

        }
    }
}
