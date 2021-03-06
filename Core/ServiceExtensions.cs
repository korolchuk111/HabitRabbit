using AutoMapper;
using Core.Interfaces.Services;
using Core.Profiles;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IFrequencyService, FrequencyService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new UnitProfile());
                mc.AddProfile(new FrequencyProfile());
            });

            var mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
