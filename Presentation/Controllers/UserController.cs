using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // دریافت لیست همه کاربران
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allUsers = await _mediator.Send(new GetAllUsersQuery());
        return Ok(allUsers);
    }

    /// <summary>
    /// دریافت کاربر
    /// </summary>
    /// <param name="id">شناسه ی کاربر</param>
    /// <returns>کاربر</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // افزودن کاربر جدید
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = userId }, null);
    }

    // ویرایش اطلاعات کاربر
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        if (!result)
            return NotFound();
        return NoContent();
    }

    // حذف کاربر
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));
        if (!result)
            return NotFound();
        return NoContent();
    }
}
