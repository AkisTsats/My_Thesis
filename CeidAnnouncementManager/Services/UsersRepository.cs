using DTOs.Data;
using static DTOs.Common.Helpers;

namespace CeidAnnouncementManager.Services
{
    public class UsersRepository
    {
        private readonly HttpClient _http;

        public UsersRepository(HttpClient http)
        {
            _http = http;
        }

        const string BaseUrl = "https://localhost:5001"; //TODO move to appsettings.json

        public async Task<UserDTO> GetMe()
        {
            var response = await _http.GetStringAsync(BaseUrl + "/api/user/getme");
            var deserializedResponse = response.DeserializeMethod<UserDTO>();

            return deserializedResponse;
        }
    }
}
