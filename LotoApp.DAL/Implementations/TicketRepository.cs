using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    //public class TicketRepository : GenericRepository<Ticket, Guid>, ITicketRepository
    public class TicketRepository : GenericRepository<Ticket, Guid>, ITicketRepository
    {
        public TicketRepository(AppDbContext appDbContext) :base(appDbContext)
        {

        }
    }
}
