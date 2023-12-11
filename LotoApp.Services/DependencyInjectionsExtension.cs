using LotoApp.DAL.Implementations;
using LotoApp.DAL.Interfaces;
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

            // Repositories
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IDrawRepository, DrawRepository>();
            services.AddScoped<IWinnerRepository, WinnerRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
