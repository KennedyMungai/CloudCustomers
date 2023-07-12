using CloudCustomers.API.Services;

namespace CloudCustomers.Tests.Systems.Services;


public class TestUserService
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesHttpHetRequest()
    {
        // Arrange
        var sut = new UserService();
        // Act
        await sut.GetAllUsers();
        // Assert
    }
}