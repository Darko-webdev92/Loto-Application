using LotoApp.DAL;
using LotoApp.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpGet("Board")]
        public IActionResult WinnersBoard()
        {            var data = _appDbContext.Winners;
            var viewData = data.Select(x => WinnerMapper.ToWinner(x));
            return Ok(data);
        }

    }
}
