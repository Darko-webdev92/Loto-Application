using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    //public class WinnerRepository : IWinnerRepository
    public class WinnerRepository : GenericRepository<Winner, Guid>, IWinnerRepository
    {
        private readonly AppDbContext _appDbContext;

        public WinnerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task AddWinners(IEnumerable<Winner> winners)
        {
            _appDbContext.Winners.AddRange(winners);
            await _appDbContext.SaveChangesAsync();
        }

        //public async Task<IEnumerable<Winner>> GetWinners()
        //{
        //    return _appDbContext.Winners;
        //}
    }
}
