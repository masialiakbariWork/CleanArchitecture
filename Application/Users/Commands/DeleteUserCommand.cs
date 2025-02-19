using MediatR;

namespace Application.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<bool>;