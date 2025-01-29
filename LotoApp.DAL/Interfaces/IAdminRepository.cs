using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Draw, Guid>
    {
    }
}
