using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
    }
}
