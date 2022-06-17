using System;
using System.Threading.Tasks;
using Shared.UserDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Client.Infrastructure
{
    public class HttpAuthorizationService : BaseHttpService
    {
        public HttpAuthorizationService(HttpClient httpClient) : base(httpClient) { }

        public async Task<string> RegisterAsync(UserRegistrationDTO userRegistrationDto)
        {
            var response = await HttpClient.PostAsJsonAsync($"/api/Authorization/register", userRegistrationDto);
            return await response.Content.ReadAsStringAsync();
        }
        
        public async Task<string> LoginAsync(UserLoginDTO user)
        {
            var response = await HttpClient.PostAsJsonAsync($"/api/Authorization/login", user);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<UserDTO?> GetUserByJwt(string token)
        {
            try
            {
                var response = await HttpClient
                    .GetFromJsonAsync<UserDTO?>($"/api/Authorization/get-user-by-jwt?token={token}");
                if (response != null) return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(1 + e.Message);
                return null;
            }
            return null;
        }
    }
}
