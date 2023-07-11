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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUsersEndpoint()
    {
        var users = await _usersService.GetAllUsers();

        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
    }
}
