namespace CloudCustomers.Tests.Systems.Controllers;

using CloudCustomers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using Moq;
using CloudCustomers.API.Services;
using CloudCustomers.API.Models;
using CloudCustomers.Tests.Fixtures;

public class TestUsersController
{
    [Fact]
    public async Task GetUsersEndpoint_OnSuccess_ReturnsStatusCode200OK()
    {
        // Arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.GetUsersEndpoint() as OkObjectResult;
        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetUsersEndpoint_OnSuccess_InvokeUserServiceExactlyOnce()
    {
        // Arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.GetUsersEndpoint();
        // Assert
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once);
    }

    [Fact]
    public async Task GetUsersEndpoint_OnSuccess_ReturnsListOfUsers()
    {
        // Arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.GetUsersEndpoint() as OkObjectResult;
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = result as OkObjectResult;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetUsersEndpoint_OnNoUsersFound_ReturnsStatusCode404NotFound()
    {
        // Arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.GetUsersEndpoint() as OkObjectResult;
        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = result;
        objectResult.StatusCode.Should().Be(404);
    }
}