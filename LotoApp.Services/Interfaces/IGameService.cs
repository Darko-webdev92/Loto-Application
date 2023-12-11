using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IGameService
    {
       Task<GameManagerResponse> EnterTicket(TicketViewModel model, string userId);
    }
}
