using DM.Shared.Infrastructure.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddControllers()
                .ConfigureApplicationPartManager(manager
                    => manager.FeatureProviders.Add(new InternalControllerFeatureProvider()));

            return services;
        }
    }
}
