using MediatR;

namespace Application.Users.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string PasswordHash) : IRequest<Guid>;