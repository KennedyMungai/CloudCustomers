using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.Tests.Fixtures;
using CloudCustomers.Tests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;

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
        handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                );
    }


    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandlers<User>.SetupBasicGetResourceList(expectedResponse: expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);
        // Act
        var result = await sut.GetAllUsers();
        // Assert
        result.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersWithCorrectCount()
    {
        // Arrange
        var handlerMock = MockHttpMessageHandlers<User>.SetupReturn404();
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);

        // Act
        var result = await sut.GetAllUsers();

        // Assert
        result.Count().Should().Be(0);
    }
}