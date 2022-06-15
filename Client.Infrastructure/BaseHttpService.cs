using System.Net.Http;

namespace Client.Infrastructure
{
    public class BaseHttpService
    {
        protected readonly HttpClient HttpClient;

        public BaseHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}