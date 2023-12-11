﻿using LotoApp.DAL.Interfaces;
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
            var winners = await _winnerRepository.GetWinners();
            var data = winners.Select(x => WinnerMapper.ToWinner(x));
            return data;
        }
    }
}
