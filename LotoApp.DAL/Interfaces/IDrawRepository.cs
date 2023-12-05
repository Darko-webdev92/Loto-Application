using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface IDrawRepository
    {
        Task<IEnumerable<Draw>> GetAll();
        Task<Draw> GetLast();
        Task Update(Draw entity);
    }
}
