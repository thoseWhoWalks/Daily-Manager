using DM.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSharedInfrastructure(this IApplicationBuilder builder)
        {
            builder
                .UseDbConsistencyPolicy()
                .UseGlobalExceptionHandler();

            return builder;
        }

        #region Private methods

        private static IApplicationBuilder UseDbConsistencyPolicy(this IApplicationBuilder builder)
        {
            var dbContextTypes = AppDomain.CurrentDomain
                .GetClientAssemblies()
                .SelectMany(@as => @as
                        .GetTypes()
                        .Where(t => t.IsSubclassOf(typeof(DbContext)) && !t.IsAbstract));

            using var scope = builder.ApplicationServices.CreateScope();

            foreach (var type in dbContextTypes)
            {
                var context = scope.ServiceProvider.GetRequiredService(type) as DbContext;

                context?.Database.EnsureCreated();
                context?.Database.Migrate();
            }

            return builder;
        }

        private static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();

            return builder;
        }

        #endregion
    }
}
