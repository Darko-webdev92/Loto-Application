using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<WinnerViewModel>> GetAllWinners();
    }
}
