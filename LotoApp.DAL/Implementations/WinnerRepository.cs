using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    public class WinnerRepository : GenericRepository<Winner, Guid>, IWinnerRepository
    {
        public WinnerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
