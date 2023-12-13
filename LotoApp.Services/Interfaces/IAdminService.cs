using LotoApp.Models;
using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IAdminService
    {
        Task<GameManagerResponse> StartSession();
        Task<GameManagerResponse> CheckSession();
        Task<GameManagerResponse> EndSession();
        Task<List<WinnerViewModel>> StartDraw();
        Task<DrawnNumbers> DrawNumbers();
        //Task<List<WinnerViewModel>> WinningTickets(List<Ticket> ticket, DrawnNumbers drawnNumbers);
    }
}
