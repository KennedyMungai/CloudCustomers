using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}