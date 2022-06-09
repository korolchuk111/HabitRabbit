using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace Client.Infrastructure
{
    public class HttpAuthorizationRepository : HttpBaseRepository
    {
        public HttpAuthorizationRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task RegisterAsync(UserDTO user)
        {
            await _httpClient.PostAsJsonAsync($"/api/User/register", user);
        }
    }
}