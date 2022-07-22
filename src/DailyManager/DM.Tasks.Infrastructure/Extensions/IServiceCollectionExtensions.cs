using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Infrastructure.Context;
using DM.Modules.Tasks.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Modules.Tasks.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        #region Private fields

        private static readonly string _dbConnectionString = "TaskDbConnectionString";

        #endregion

        public static IServiceCollection AddTasksInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabase(configuration)
                .AddRepositories(configuration);

            return services;
        }

        #region Private methods

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString(_dbConnectionString)));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }

        #endregion

    }
}
