namespace CloudCustomers.Tests.Systems.Controllers;

using CloudCustomers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using Moq;
using CloudCustomers.API.Services;
using CloudCustomers.API.Models;

public class TestUsersController
{
    // [Fact]
    // public async Task GetUsersEndpoint_OnSuccess_ReturnsStatusCode200OK()
    // {
    //     // Arrange
    //     var sut = new UsersController();
    //     // Act
    //     var result = await sut.GetUsersEndpoint() as OkObjectResult;
    //     // Assert
    //     result.StatusCode.Should().Be(200);
    // }

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
}