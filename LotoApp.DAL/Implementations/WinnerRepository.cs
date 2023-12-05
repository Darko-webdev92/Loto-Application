using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    public class WinnerRepository : IWinnerRepository
    {
        private readonly AppDbContext _appDbContext;

        public WinnerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddWinners(IEnumerable<Winner> winners)
        {
            _appDbContext.Winners.AddRange(winners);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
