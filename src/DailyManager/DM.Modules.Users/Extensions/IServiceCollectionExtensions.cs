﻿using DM.Module.Users.Authenctication;
using DM.Module.Users.Context;
using DM.Module.Users.Models;
using DM.Module.Users.Services;
using DM.Modules.Users.Events;
using DM.Shared.Application.Mapping;
using DM.Shared.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DM.Module.Users.Extensions
{
    public static class IServiceCollectionExtensions
    {
        #region Private fields

        private static readonly string _dbConnectionString = "UserDbConnectionString";

        #endregion

        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabase(configuration)
                .AddServises(configuration)
                .AddUserContext(configuration)
                .AddEvents(configuration)
                .AddMappings(configuration);

            return services;
        }

        #region Private methods

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options 
                => options.UseSqlServer(configuration.GetConnectionString(_dbConnectionString)));

            return services;
        }

        private static IServiceCollection AddServises(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddUserContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserContext>(provider => {
                // TODO: User IAuthenticator.
                AuthUserModel auth = new AuthUserModel(Guid.Parse("17CD365B-4E84-4177-985C-21579ED031FC"));

                return new UserContext(auth);
            });

            return services;
        }

        public static IServiceCollection AddEvents(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserEventDispatcher, UserEventDispatcher>();

            return services;
        }

        public static IServiceCollection AddMappings(this IServiceCollection services, IConfiguration config)
        {
            new MapperRegistrator().FromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        #endregion
    }
}
