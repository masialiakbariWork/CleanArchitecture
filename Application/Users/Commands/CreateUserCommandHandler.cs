using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FirstName, request.LastName, request.Email, request.PasswordHash);
        await _userRepository.AddAsync(user);
        return user.Id;
    }
}