using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _usersService;

    public UsersController(IUserService userService)
    {
        _usersService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> GetUsersEndpoint()
    {
        return Ok();
    }
}
