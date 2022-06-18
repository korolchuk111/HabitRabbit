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
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDailyTaskService, DailyTaskService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new UnitProfile());
                mc.AddProfile(new FrequencyProfile());
                mc.AddProfile(new ChallengeProfile());
                mc.AddProfile(new DailyTaskProfile());
            });

            var mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
