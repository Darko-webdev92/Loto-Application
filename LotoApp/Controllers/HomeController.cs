using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public HomeController(IBoardService boardService)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
        }

        [HttpGet("Board")]
        public async Task<IActionResult> WinnersBoard()
        {
            try
            {
                var data = await _boardService.GetAllWinners();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
