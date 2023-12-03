using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IGameService
    {
        GameManagerResponse EnterTicket(TicketViewModel model, string userId);
    }
}
