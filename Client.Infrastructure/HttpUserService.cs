using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.UserDTO;

namespace Client.Infrastructure
{
    public class HttpUserService : BaseHttpService
    {
        public HttpUserService(HttpClient httpClient) : base(httpClient) { }
        
        public async Task<UserDTO?> GetUser(string userName)
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<UserDTO>($"api/user?userName={userName}");
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public async Task UpdateUser(UpdateUserDTO user)
        {
            await HttpClient.PutAsJsonAsync("api/user/update", user);
        }
    }
}
