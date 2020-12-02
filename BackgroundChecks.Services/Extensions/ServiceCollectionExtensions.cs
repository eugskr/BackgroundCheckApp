using BackgroundChecks.Services.CheckRepo;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundChecks.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCheckRepoService(this IServiceCollection services)
        {
            services.AddTransient<ICheckService, CheckService>();
            return services;
        }
    }
}
