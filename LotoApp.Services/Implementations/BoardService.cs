using LotoApp.DAL.Interfaces;
using LotoApp.Models.Dto;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;

namespace LotoApp.Services.Implementations
{
    internal class BoardService : IBoardService
    {
        private readonly IWinnerRepository _winnerRepository;

        public BoardService(IWinnerRepository winnerRepository)
        {
            _winnerRepository = winnerRepository ?? throw new ArgumentNullException(nameof(winnerRepository));
        }

        public async Task<IEnumerable<WinnerViewModel>> GetAllWinners()
        {
            throw new Exception();
            var winners = await _winnerRepository.GetAll();
            var data = winners.Select(x => WinnerDto.ToWinnerViewModelDto(x));
            return data; 
        }
    }
}
