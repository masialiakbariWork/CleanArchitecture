using MediatR;

namespace Application.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
