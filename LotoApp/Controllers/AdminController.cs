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
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        [HttpPost("StartSession")]
        public async Task<IActionResult> StartSession()
        {
            await _adminService.StartSession();
            return Ok("Session is activated");
        }

        [HttpPut("StartDraw")]
        public async Task<IActionResult> StartDraw()
        {
           var winners = await _adminService.StartDraw();
            if(winners.Count > 0)
            {
                return Ok(winners);

            }
            return Ok("There are no winners this session");
        }
    }
}
