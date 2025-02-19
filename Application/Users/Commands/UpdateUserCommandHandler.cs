using Domain.Interfaces;
using MediatR;

namespace Application.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null) return false;

        user.UpdateName(request.FirstName, request.LastName);
        user.UpdateEmail(request.Email);
        await _userRepository.UpdateAsync(user);
        return true;
    }
}