using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    //public interface IAdminRepository
    public interface IAdminRepository : IGenericRepository<Draw, Guid>
    {
        //Task Add(Draw entity);
    }
}
