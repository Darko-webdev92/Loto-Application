using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket, Guid>
    {
        //Task<IEnumerable<Ticket>> GetAll();
        //Task Add(Ticket entity);
    }
}
