namespace CloudCustomers.Test.Systems.Controllers;

using CloudCustomers.API.Controllers;

public class TestUsersController
{
    [Fact]
    public void GetUsersEndpoint_OnSuccess_ReturnsStatusCode200OK()
    {
        // Arrange
        var sut = new UsersController();
        // Act
        var result = sut.GetUsersEndpoint();
        // Assert
        result.StatusCode.Should().Be(200);
    }
}