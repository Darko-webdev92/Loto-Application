using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface IWinnerRepository
    {
        Task AddWinners(IEnumerable<Winner> winners);
        Task<IEnumerable<Winner>> GetWinners();
    }
}
