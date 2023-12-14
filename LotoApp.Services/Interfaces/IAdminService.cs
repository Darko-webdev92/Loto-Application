using LotoApp.Models;
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
    }
}
