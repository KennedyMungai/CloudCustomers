namespace CloudCustomers.Tests.Systems.Controllers;

using CloudCustomers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using Moq;
using CloudCustomers.API.Services;

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
    public async Task GetUsersEndpoint_OnSuccess_InvokeUserService()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var sut = new UsersController(mockUserService.Object);
        // Act
        var result = await sut.GetUsersEndpoint() as OkObjectResult;
        // Assert
    }
}