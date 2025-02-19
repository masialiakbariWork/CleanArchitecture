using MediatR;

namespace Application.Users.Commands;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName, string Email) : IRequest<bool>;