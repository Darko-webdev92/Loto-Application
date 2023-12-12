using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    //public class TicketRepository : GenericRepository<Ticket, Guid>, ITicketRepository
    public class TicketRepository : GenericRepository<Ticket, Guid>, ITicketRepository
    {
        //private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext) :base(appDbContext)
        {
            //_appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        //public async Task Add(Ticket entity)
        //{
        //    _appDbContext.Tickets.Add(entity);
        //   await _appDbContext.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Ticket>> GetAll()
        //{
        //   return _appDbContext.Tickets;
        //}

    }
}
