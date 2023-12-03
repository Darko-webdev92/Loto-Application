using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IBoardService
    {
        Task<WinnerViewModel> GetAllWinners();
    }
}
