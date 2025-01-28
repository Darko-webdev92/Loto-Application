using FakeItEasy;
using LotoApp.Controllers;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace YourNamespace.Tests
{
    public class HomeControllerTests
    {
        private readonly IBoardService _boardServiceMock;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _boardServiceMock = A.Fake<IBoardService>();
            _controller = new HomeController(_boardServiceMock);
        }

        [Fact]
        public async Task WinnersBoard_ShouldReturnOkWithWinnersData()
        {
            // Arrange
            var winners = new List<WinnerViewModel>();
            winners.Add(new WinnerViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Prize = LotoApp.Models.Enums.Prize.Vocation,
                SessionId = 2,
            });

            A.CallTo(() => _boardServiceMock.GetAllWinners())
                   .Returns(Task.FromResult(winners.AsEnumerable()));

            // Act
            var result = await _controller.WinnersBoard();


            #region Fluent Assertions Way
            // Assert
            //var okResult = result as OkObjectResult;   
            //okResult.Should().NotBeNull();
            //okResult!.StatusCode.Should().Be(200);
            //okResult.Value.Should().BeEquivalentTo(winners);
            #endregion

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(winners, okResult.Value);
        }

        [Fact]
        public async Task WinnersBoard_ShouldReturnOkWithNoWinnersData()
        {
            // Arrange
            var winners = new List<WinnerViewModel>();

            A.CallTo(() => _boardServiceMock.GetAllWinners())
                   .Returns(Task.FromResult(winners.AsEnumerable()));

            // Act
            var result = await _controller.WinnersBoard();

            #region Fluent Assertions way
            // Assert
            //var okResult = result as OkObjectResult;
            //okResult.Should().NotBeNull();
            //okResult!.StatusCode.Should().Be(200);
            //okResult.Value.Should().BeEquivalentTo(winners); 
            #endregion

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(winners, okResult.Value);
        }
    }
}
