using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LotoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(UserManager<ApplicationUser> userManager, IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("EnterTicket")]
        public IActionResult EnterTicket([FromBody] TicketViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentnty = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentnty.FindFirst(ClaimTypes.NameIdentifier).Value;
               var result = _gameService.EnterTicket(model, claims);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
