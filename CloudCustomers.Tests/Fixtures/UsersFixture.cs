using CloudCustomers.API.Models;

namespace CloudCustomers.Tests.Fixtures;


public static class UsersFixture
{
    public static List<User> GetTestUsers() => new()
    {
        new User
        {
            Name = "Test User 1",
            Email = "test@user.com",
            Address = new Address
            {
                Street = "123 Main St",
                City = "Los Angeles",
                ZipCode = "12345"
            }
        },
        new User
        {
            Name = "Test User 2",
            Email = "test2@user.com",
            Address = new Address
            {
                Street = "1234 Main St",
                City = "Los Angeles 4",
                ZipCode = "123465"
            }
        },
        new User
        {
            Name = "Test User 3",
            Email = "test3@user.com",
            Address = new Address
            {
                Street = "12345 Main St",
                City = "Los Angeles 45",
                ZipCode = "1234656"
            }
        }
    };
}