using DM.Module.Users.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Module.Users.Extensions
{
    public static class IServiceCollectionExtensions
    {
        #region Private fields

        private static readonly string _dbConnectionString = "UserDbConnectionString";

        #endregion

        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            return services;
        }

        #region Private methods

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options 
                => options.UseSqlServer(configuration.GetConnectionString(_dbConnectionString)));

            return services;
        }

        #endregion
    }
}
