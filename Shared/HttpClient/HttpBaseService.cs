namespace HttpClient
{
    public class HttpBaseService
    {
        protected readonly System.Net.Http.HttpClient HttpClient;

        protected HttpBaseService(System.Net.Http.HttpClient httpClient)
            {
                HttpClient = httpClient;
            }
    }
}
