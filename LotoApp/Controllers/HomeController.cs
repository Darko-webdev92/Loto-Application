﻿using LotoApp.DAL;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public HomeController(IBoardService boardService)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
        }

        [HttpGet("Board")]
        public IActionResult WinnersBoard()
        {           
            var data = _boardService.GetAllWinners();
            return Ok(data);
        }
    }
}
