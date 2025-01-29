using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    public class DrawRepository : GenericRepository<Draw, Guid>, IDrawRepository
    {
        public DrawRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
