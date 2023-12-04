using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Draw entity)
        {
            _appDbContext.Draws.Add(entity);
            _appDbContext.SaveChangesAsync();
        }
    }
}
