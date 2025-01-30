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
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogError(ex, "An error occurred in Admin/StartSession");
                return BadRequest("An error occurred while processing your request.");
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
                _logger.LogError(ex, "An error occurred in Admin/StartDraw");
                return BadRequest("An error occurred while processing your request.");
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
                _logger.LogError(ex, "An error occurred in Admin/CheckSession");
                return BadRequest("An error occurred while processing your request.");
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
                _logger.LogError(ex, "An error occurred in Admin/EndSession");
                return BadRequest("An error occurred while processing your request.");
            }
        }
    }
}
