using System.Net.Http;
using System.Threading.Tasks;
using Shared.UserDTO;
using System.Net.Http.Json;

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
    }
}