using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        { }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            { });

            var mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
