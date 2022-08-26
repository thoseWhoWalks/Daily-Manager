using DM.Modules.Tasks.Core.Factories.TaskLists;
using DM.Modules.Tasks.Core.Factories.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFactory = DM.Modules.Tasks.Core.Factories.Tasks.TaskFactory;

namespace DM.Modules.Tasks.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTasksCore(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFactories(configuration);

            return services;
        }

        #region Private methods

        private static IServiceCollection AddFactories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITaskFactory, TaskFactory>();
            services.AddScoped<ITaskListFactory, TaskListFactory>();

            return services;
        }

        #endregion

    }
}
