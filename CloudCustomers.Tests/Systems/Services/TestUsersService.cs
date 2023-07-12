using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.Tests.Fixtures;
using CloudCustomers.Tests.Helpers;

namespace CloudCustomers.Tests.Systems.Services;


public class TestUserService
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesHttpHetRequest()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandlers<User>.SetupBasicGetResourceList(expectedResponse: expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);
        // Act
        await sut.GetAllUsers();
        // Assert
    }
}