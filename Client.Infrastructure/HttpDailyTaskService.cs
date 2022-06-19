using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.DailyTaskDTO;

namespace Client.Infrastructure
{
    public class HttpDailyTaskService : BaseHttpService
    {
        public HttpDailyTaskService(HttpClient httpClient) : base(httpClient) {}

        public async Task<IList<DailyTaskDTO>?> GetAllTasksForToday(string userName)
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<IList<DailyTaskDTO>>
                                ($"api/DailyTask/today?userName={userName}");
                Console.WriteLine(response);
                return response;
            }
            catch (Exception)
            {
                return new List<DailyTaskDTO>();
            }
        }
    }
}