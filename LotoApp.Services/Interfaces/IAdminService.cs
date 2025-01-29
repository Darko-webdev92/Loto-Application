using LotoApp.Models;
using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IAdminService
    {
        Task<GameManagerResponse> StartSession();
        Task<GameManagerResponse> CheckSession();
        Task<GameManagerResponse> EndSession();
        Task<IEnumerable<WinnerViewModel>> StartDraw();
        Task<DrawnNumbers> DrawNumbers();
    }
}
