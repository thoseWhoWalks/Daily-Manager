using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        #region Constants

        private const string DmAssemblyPrefix = "DM.Modules.";

        #endregion

        public static IApplicationBuilder UseSharedInfrastructure(this IApplicationBuilder builder)
        {
            builder
                .UseDbConsistencyPolicy();

            return builder;
        }

        #region Private methods

        private static IApplicationBuilder UseDbConsistencyPolicy(this IApplicationBuilder builder)
        {
            var dbContextTypes = AppDomain.CurrentDomain
                .GetAssemblies().Where(a => !string.IsNullOrEmpty(a.FullName) && a.FullName.Contains(DmAssemblyPrefix))
                .SelectMany(@as => @as.GetTypes().Where(t => t.IsSubclassOf(typeof(DbContext))));

            using var scope = builder.ApplicationServices.CreateScope();

            foreach (var type in dbContextTypes)
            {
                var context = scope.ServiceProvider.GetRequiredService(type) as DbContext;

                context?.Database.EnsureCreated();
                context?.Database.Migrate();
            }

            return builder;
        }

        #endregion
    }
}
