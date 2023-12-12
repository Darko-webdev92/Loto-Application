using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    //public class AdminRepository : IAdminRepository
    public class AdminRepository : GenericRepository<Draw, Guid>, IAdminRepository
    {
        //private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            //_appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        //public async Task Add(Draw entity)
        //{
        //    _appDbContext.Draws.Add(entity);
        //   await _appDbContext.SaveChangesAsync();
        //}
    }
}
