using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

/// <summary>
/// درخواست دریافت کاربر
/// </summary>
/// <param name="Id">شناسه ی کاربر</param>
public record GetUserByIdQuery(Guid Id) : IRequest<User?>;