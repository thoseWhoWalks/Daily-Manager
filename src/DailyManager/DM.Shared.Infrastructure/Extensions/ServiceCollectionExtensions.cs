using DM.Shared.Application.Commands;
using DM.Shared.Application.Queries;
using DM.Shared.Infrastructure.Commands;
using DM.Shared.Infrastructure.Controllers;
using DM.Shared.Infrastructure.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddMediatR(AppDomain.CurrentDomain.GetClientAssemblies())
                .AddQueries()
                .AddCommands()
                .AddInternalControllerFeatureProvider(config);

            return services;
        }

        #region Private methods

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetClientAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetClientAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        private static IServiceCollection AddInternalControllerFeatureProvider(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddControllers()
                .ConfigureApplicationPartManager(manager
                    => manager.FeatureProviders.Add(new InternalControllerFeatureProvider()));

            return services;
        }

        #endregion
    }
}
