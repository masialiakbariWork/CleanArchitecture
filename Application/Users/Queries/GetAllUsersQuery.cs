using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

/// <summary>
/// درخواست دریافت لیست تمام کاربران
/// </summary>
public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;