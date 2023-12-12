using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    //public class DrawRepository : IDrawRepository
    public class DrawRepository : GenericRepository<Draw, Guid>, IDrawRepository

    {
        //private readonly AppDbContext _appDbContext;

        public DrawRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            //_appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        //public async Task<IEnumerable<Draw>> GetAll()
        //{
        //    return _appDbContext.Draws;
        //}

        //public async Task<Draw> GetLast()
        //{
        //    return await _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefaultAsync();
        //}

        //public async Task Update(Draw entity)
        //{
        //    _appDbContext.Draws.Update(entity);
        //  await _appDbContext.SaveChangesAsync();
        //}
    }
}
