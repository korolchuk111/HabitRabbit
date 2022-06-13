using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.UserDTO;

namespace HttpClient
{
    public class HttpAuthorizationService : HttpBaseService
    {

        public HttpAuthorizationService(System.Net.Http.HttpClient httpClient) : base(httpClient) { }
        
        public async Task RegisterAsync(UserRegistrationDTO user)
        {
            await HttpClient.PostAsJsonAsync($"/api/Authorization/register", user);
        }
        
        public async Task<string> LoginAsync(UserLoginDTO user)
        {
            var response = await HttpClient.PostAsJsonAsync($"/api/Authorization/login", user);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
