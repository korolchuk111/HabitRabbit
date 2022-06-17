using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Shared.ChallengeDTO;

namespace Client.Infrastructure
{
    public class HttpChallengeService : BaseHttpService
    {
        public HttpChallengeService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IList<ChallengeDTO>?> GetChallengesByUser(string userName)
        {
            var response = await HttpClient.GetFromJsonAsync<IList<ChallengeDTO>>
                ($"api/challenge?userName={userName}");
            foreach (var challenge in response)
            {
                Console.WriteLine(challenge.Title);
            }
            return response;
        }
    }
}