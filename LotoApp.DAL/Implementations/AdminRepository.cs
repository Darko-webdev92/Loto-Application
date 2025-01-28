using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;

namespace LotoApp.DAL.Implementations
{
    public class AdminRepository : GenericRepository<Draw, Guid>, IAdminRepository
    {
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

    }
}
