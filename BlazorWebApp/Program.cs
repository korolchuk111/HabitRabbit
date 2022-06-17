global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Client.Infrastructure;

namespace BlazorWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("public", 
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddScoped(sp => new System.Net.Http.HttpClient 
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddAuthorizationCore();
            
            builder.Services.AddScoped<HttpAuthorizationService>();
            builder.Services.AddScoped<HttpChallengeService>();
            builder.Services.AddBlazoredLocalStorage();
            
            await builder.Build().RunAsync();
        }
    }
}
