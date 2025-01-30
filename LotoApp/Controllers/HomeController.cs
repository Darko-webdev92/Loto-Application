using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IBoardService boardService, ILogger<HomeController> logger)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IBoardService BoardService => _boardService;

        [HttpGet("Board")]
        public async Task<IActionResult> WinnersBoard()
        {
            try
            {
                var data = await BoardService.GetAllWinners();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Index/WinnersBoard");
                return BadRequest("An error occurred while processing your request.");
            }
        }
    }
}
