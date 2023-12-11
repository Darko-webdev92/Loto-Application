using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;
using System;
using System.Net.Sockets;

namespace LotoApp.DAL.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Ticket entity)
        {
            _appDbContext.Tickets.Add(entity);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
           return _appDbContext.Tickets;
        }

    }
}
