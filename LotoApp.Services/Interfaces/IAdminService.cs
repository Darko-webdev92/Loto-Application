using LotoApp.Models;
using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IAdminService
    {
        Task StartSession();
        Task<GameManagerResponse> CheckSession();
        Task EndSession();
        Task<List<WinnerViewModel>> StartDraw();
        Task<DrawnNumbers> DrawNumbers();
        List<WinnerViewModel> WinningTickets(List<Ticket> ticket, DrawnNumbers drawnNumbers);
    }
}
