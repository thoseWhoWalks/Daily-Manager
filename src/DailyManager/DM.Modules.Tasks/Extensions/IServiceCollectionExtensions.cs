using DM.Modules.Tasks.Application.Extensions;
using DM.Modules.Tasks.Core.Extensions;
using DM.Modules.Tasks.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Modules.Tasks.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTasksModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTasksCore(configuration)
                .AddTasksInfrastructure(configuration)
                .AddTasksApplication(configuration);

            return services;
        }
    }
}
