using APIIClient.Models;
using APIIClient.Models.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;

namespace APIIClient
{
    
    public class APIClientService
    {
        private readonly HttpClient _httpClient;

        public APIClientService(APIClientOptions options)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(options.ApiBaseAddress);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<User>?>("/api/Users");
        }


        public async Task<User> GetUserById(Int64 id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"/api/Users/{id}");
        }

        public async Task SaveUser(User user)
        {
             await _httpClient.PostAsJsonAsync("/api/users/", user);
        }

        public async Task UpdateUser(User user)
        {
            await _httpClient.PutAsJsonAsync("/api/users/", user);
        }

        public async Task DeleteUser(Int64 id)
        {
            await _httpClient.DeleteAsync($"/api/users/{id}");
        }


    }
}
