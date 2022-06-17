using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Client.Infrastructure;
using Shared.UserDTO;

namespace BlazorWebApp
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpAuthorizationService _httpAuthorizationService;
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(
            ILocalStorageService localStorage,
            HttpAuthorizationService httpAuthorizationService,
            HttpClient httpClient
            )
        {
            _localStorage = localStorage;
            _httpAuthorizationService = httpAuthorizationService;
            _httpClient = httpClient;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("access_token");

            if (token == null || token.Equals(string.Empty))
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            var user = await GetUserByJwtAsync(token);
            var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            if (user != null)
            {
                var claims = GetClaimsPrinciple(user);
                state = new AuthenticationState(claims);
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            
                NotifyAuthenticationStateChanged(Task.FromResult(state));
            }
            else
            {
                await _localStorage.RemoveItemAsync("access_token");
            }

            return state;
        }

        private async Task<UserDTO> GetUserByJwtAsync(string token)
        {
            if (token == null) return null;
            return await _httpAuthorizationService.GetUserByJwt(token);
        }

        private static ClaimsPrincipal GetClaimsPrinciple(UserDTO currentUser)
        {
            //create a claims
            var claimEmailAddress = new Claim(ClaimTypes.Email, currentUser.Email);
            var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.Id));
            var claimName = new Claim(ClaimTypes.Name, Convert.ToString(currentUser.UserName));
            //create claimsIdentity
            var claimsIdentity = new ClaimsIdentity(new[] { claimEmailAddress, claimNameIdentifier, claimName }, "serverAuth");
            //create claimsPrincipal
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}