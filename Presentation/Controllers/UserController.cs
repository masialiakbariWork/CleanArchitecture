using Application.User.Commands;
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
    public async Task<IActionResult> Create(string name, string family, string email)
    {
        var command = new CreateUserCommand()
        {
            Name = name,
            Family = family,
            Email = email
        };
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
