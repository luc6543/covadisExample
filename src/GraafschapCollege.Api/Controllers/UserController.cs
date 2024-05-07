namespace Covadis.Api.Controllers;

using GraafschapCollege.Api.Entities;
using GraafschapCollege.Api.Services;

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
        var user = userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        var createdUser = userService.CreateUser(user);

        return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
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
