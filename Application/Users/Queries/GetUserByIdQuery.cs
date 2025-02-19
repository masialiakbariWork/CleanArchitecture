using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<User?>;