using LotoApp.Services.Implementations;
using LotoApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Utilities
{
    public static class DependencyInjectionsExtension
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }


        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {

            return services;
        }
    }
}
