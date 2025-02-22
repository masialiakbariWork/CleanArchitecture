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

    /// <summary>
    /// ایجاد کاربر جدید
    /// </summary>
    /// <param name="request">درخواست ایجاد کاربر جدید</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User(request.FirstName, request.LastName, request.Email, request.PasswordHash);
        await _userRepository.AddAsync(newUser);
        return newUser.Id;
    }
}