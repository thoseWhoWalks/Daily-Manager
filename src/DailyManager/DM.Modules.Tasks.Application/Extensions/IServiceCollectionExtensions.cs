using DM.Shared.Application.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DM.Modules.Tasks.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTasksApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMappings(configuration);

            return services;
        }

        #region Private methods

        public static IServiceCollection AddMappings(this IServiceCollection services, IConfiguration config)
        {
            new MapperRegistrator().FromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        #endregion
    }
}
