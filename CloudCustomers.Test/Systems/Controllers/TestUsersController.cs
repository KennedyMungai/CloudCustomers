namespace CloudCustomers.Test.Systems.Controllers;

using CloudCustomers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

public class TestUsersController
{
    [Fact]
    public async Task GetUsersEndpoint_OnSuccess_ReturnsStatusCode200OK()
    {
        // Arrange
        var sut = new UsersController();
        // Act
        var result = (OkObjectResult)await sut.GetUsersEndpoint();
        // Assert
        result.StatusCode.Should().Be(200);
    }
}