using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.UserDTO;
using WebAPI.DTO;

namespace Client.Infrastructure
{
    public class HttpAuthorizationRepository : HttpBaseRepository
    {
        public HttpAuthorizationRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task RegisterAsync(UserRegistrationDTO user)
        {
            await _httpClient.PostAsJsonAsync($"/api/Authorization/register", user);
        }
    }
}