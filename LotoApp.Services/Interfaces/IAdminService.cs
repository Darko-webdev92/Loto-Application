using LotoApp.InterfaceModels;
using LotoApp.Models;
using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IAdminService
    {
        void StartSession();
        GameManagerResponse CheckSession();
        void EndSession();
        List<WinnerViewModel> StartDraw();
        int[] RandomArray();
        DrawnNumbers DrawNumbers();
        List<WinnerViewModel> WinningTickets(List<Ticket> ticket, DrawnNumbers drawnNumbers);
    }
}
