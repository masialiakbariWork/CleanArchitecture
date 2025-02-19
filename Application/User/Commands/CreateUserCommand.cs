using MediatR;

namespace Application.User.Commands;

public class CreateUserCommand: IRequest<bool>
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
}
