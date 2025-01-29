using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LotoApp.Controllers
{
    [Route("[controller]")]
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
            try
            {
                var model = await _adminService.StartSession();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("StartDraw")]
        public async Task<IActionResult> StartDraw()
        {
            try
            {
                var winners = await _adminService.StartDraw();
                if (winners.Count() > 0)
                    return Ok(winners);

                return Ok("There are no winners this session");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CheckSession")]
        public async Task<IActionResult> CheckSession()
        {
            try
            {
                var model = await _adminService.CheckSession();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EndSession")]
        public async Task<IActionResult> EndSession()
        {
            try
            {
                var model = await _adminService.EndSession();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
