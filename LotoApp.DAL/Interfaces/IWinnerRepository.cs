using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    //public interface IWinnerRepository
    public interface IWinnerRepository : IGenericRepository<Winner, Guid>
    {
        //Task AddWinners(IEnumerable<Winner> winners);
        //Task<IEnumerable<Winner>> GetWinners();
    }
}
