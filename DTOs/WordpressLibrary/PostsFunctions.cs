﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DTOs.WordpressLibrary
{
    public class PostsFunctions
    {
        public async Task<Post> CreatePost(Post post, HttpClient client)
        {
            var jsonContent = JsonConvert.SerializeObject(post);
            var response = await client.PostAsync("wp-json/wp/v2/posts", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(responseBody);
        }

        public async Task<Post> GetPost(int id, HttpClient client)
        {
            var response = await client.GetAsync($"wp-json/wp/v2/posts/{id}");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(responseBody);
        }

        public async Task<Post> UpdatePost(int id, Post post, HttpClient client)
        {
            var jsonContent = JsonConvert.SerializeObject(post);
            var response = await client.PutAsync($"wp-json/wp/v2/posts/{id}", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(responseBody);
        }
        
        public async Task DeletePost(int id, HttpClient client)
        {
            var response = await client.DeleteAsync($"wp-json/wp/v2/posts/{id}");
            response.EnsureSuccessStatusCode();
        }


        private HttpClient CreateHttpClient(string baseUrl, string username, string password)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

    }
}