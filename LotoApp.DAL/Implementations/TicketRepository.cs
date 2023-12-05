using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;
using System;

namespace LotoApp.DAL.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Ticket>> GetAll()
        {
           return _appDbContext.Tickets;
        }
    }
}
