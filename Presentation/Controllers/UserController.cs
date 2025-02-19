using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string firstName, string lastName, string email, string passwordHash)
    {
        var command = new CreateUserCommand(firstName, lastName, email, passwordHash);
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
