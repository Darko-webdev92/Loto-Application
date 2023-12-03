using LotoApp.Services.Implementations;
using LotoApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LotoApp.Utilities
{
    public static class DependencyInjectionsExtension
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBoardService, BoardService>();

            return services;
        }


        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {

            return services;
        }
    }
}
