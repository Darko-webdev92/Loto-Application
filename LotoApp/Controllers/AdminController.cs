using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("StartSession")]
        public IActionResult StartSession()
        {
            _adminService.StartSession();
            return Ok("Session is activated");
        }

        //[HttpGet("CheckSession")]
        //public IActionResult CheckSession()
        //{
        //    var res = _adminService.CheckSession();
        //    return Ok(res);
        //}

        [HttpPut("StartDraw")]
        public IActionResult StartDraw()
        {
           var winners = _adminService.StartDraw();
            if(winners.Count > 0)
            {
                return Ok(winners);

            }
            return Ok("There are no winners this session");
        }
    }
}
