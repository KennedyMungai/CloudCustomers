using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await _httpClient.GetAsync("api/users");
            return new List<User> { };
        }
    }
}