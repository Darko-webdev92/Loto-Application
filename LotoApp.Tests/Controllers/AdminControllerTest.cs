using FakeItEasy;
using LotoApp.Controllers;
using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Xunit;

namespace LotoApp.Tests.Controllers
{
    public class AdminControllerTests
    {
        private readonly IAdminService _adminService;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _adminService = A.Fake<IAdminService>();
            _controller = new AdminController(_adminService);
        }

        [Fact]
        public async Task StartSession_ShouldReturnOk_With_Result_Session_Is_Activated()
        {
            var response = new GameManagerResponse()
            {
                Message = "Session is activated"
            };

            A.CallTo(() => _adminService.StartSession())
                   .Returns(Task.FromResult(response));

            var result = await _controller.StartSession();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task StartSession_ShouldReturnOk_With_Result_There_Is_An_Active_Session()
        {
            var response = new GameManagerResponse()
            {
                Message = "There is an active session"
            };

            A.CallTo(() => _adminService.StartSession())
                   .Returns(Task.FromResult(response));

            var result = await _controller.StartSession();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(response, okResult.Value);
        }


        [Fact]
        public async Task StartDraw_ShouldReturnOk_With_ResultWithWinnersData()
        {
            IEnumerable<WinnerViewModel> winners = new List<WinnerViewModel>()
            {
                new WinnerViewModel() {
                    FirstName = "John",
                    LastName = "Doe",
                    Prize = Models.Enums.Prize.Car,
                    SessionId = 1,
                     Number_1 = 1, Number_2 = 2, Number_3 = 3, Number_4 = 4, Number_5 = 5, Number_6 = 6, Number_7 = 7,
                },
                    new WinnerViewModel() {
                    FirstName = "John",
                    LastName = "Doe",
                    Prize = Models.Enums.Prize.TV,
                    Number_1 = 1, Number_2 = 2, Number_3 = 3, Number_4 = 4, Number_5 = 5, Number_6 = 28, Number_7 = 36,
                    SessionId = 1
                }
            };

            A.CallTo(() => _adminService.StartDraw()).Returns(Task.FromResult(winners));

            var result = await _controller.StartDraw();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(winners, okResult.Value);
        }

        [Fact]
        public async Task StartDraw_ShouldReturnOk_With_ResultWithNoWinnersData()
        {
            IEnumerable<WinnerViewModel> winners = new List<WinnerViewModel>();

            A.CallTo(() => _adminService.StartDraw()).Returns(Task.FromResult(winners));
            var result = await _controller.StartDraw();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(winners, okResult.Value);
        }
    }
}
