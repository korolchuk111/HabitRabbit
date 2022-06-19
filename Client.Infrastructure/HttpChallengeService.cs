using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Shared.ChallengeDTO;
using Shared.FrequencyDTo;
using Shared.UnitDTO;

namespace Client.Infrastructure
{
    public class HttpChallengeService : BaseHttpService
    {
        public HttpChallengeService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IList<ChallengeDTO>?> GetChallengesByUser(string userName)
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<IList<ChallengeDTO>>
                    ($"api/challenge?userName={userName}");
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public async Task CreateChallenge(CreateChallengeDTO challenge)
        {
            await HttpClient.PostAsJsonAsync("api/challenge/create", challenge);
        }

        public async Task<IList<UnitDTO>?> GetUnits()
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<IList<UnitDTO>>("api/unit");
                foreach (var unit in response)
                {
                    Console.WriteLine(unit.Type);
                }
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public async Task<IList<FrequencyDTO>?> GetFrequency()
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<IList<FrequencyDTO>>("api/frequency");
                foreach (var unit in response)
                {
                    Console.WriteLine(unit.Type);
                }
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}