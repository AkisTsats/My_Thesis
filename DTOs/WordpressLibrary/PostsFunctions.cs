using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace DTOs.WordpressLibrary
{
    public class PostsFunctions
    {
        public class CreatePostDTO
        {
            public string title { get; set; }
            public string status { get; set; }
            public string excerpt { get; set; }
            public string content { get; set; }
        }
        public async Task<Post> CreatePost(CreatePostDTO post, HttpClient client)
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


        public HttpClient CreateHttpClient(string baseUrl, string username, string password)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46cU1pMCBvMUpuIElOSE4gOTBHNSB2V3VNIG9hMTA=");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

    }
}
