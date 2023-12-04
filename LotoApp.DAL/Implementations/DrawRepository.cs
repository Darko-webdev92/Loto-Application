using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DAL.Implementations
{
    public class DrawRepository : IDrawRepository
    {
        private readonly AppDbContext _appDbContext;

        public DrawRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<IEnumerable<Draw>> GetAll()
        {
            return _appDbContext.Draws.AsNoTracking();
        }

        public async Task<Draw> GetLast()
        {
            return _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
        }
    }
}
