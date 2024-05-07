namespace Covadis.Api.Controllers;

using GraafschapCollege.Api.Entities;
using GraafschapCollege.Api.Services;
using GraafschapCollege.Shared.Requests;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var response = userService.GetUserById(id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var response = userService.CreateUser(request);

        return CreatedAtAction(nameof(CreateUser), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        var updatedUser = userService.UpdateUser(id, user);

        if (updatedUser == null)
        {
            return NotFound();
        }

        return Ok(updatedUser);
    }
}
