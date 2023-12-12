using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    //public interface IDrawRepository
    public interface IDrawRepository : IGenericRepository<Draw, Guid>
    {
        //Task<IEnumerable<Draw>> GetAll();
        //Task<Draw> GetLast();
        //Task Update(Draw entity);
    }
}
