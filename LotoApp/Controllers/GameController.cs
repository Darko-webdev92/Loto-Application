using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LotoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        [HttpPost("EnterTicket")]
        public async Task<IActionResult> EnterTicket([FromBody] TicketViewModel model)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        var claimsIdentnty = (ClaimsIdentity)User.Identity;
                        var userId = claimsIdentnty.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        var result = await _gameService.EnterTicket(model, userId);
                        return Ok(result);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Game/EnterTicket");
                return BadRequest("An error occurred while processing your request.");
            }
        }
    }
}
