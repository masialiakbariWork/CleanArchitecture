using MediatR;

namespace Application.Users.Commands;

/// <summary>
/// درخواست ایجاد کاربر جدید
/// </summary>
/// <param name="FirstName">نام</param>
/// <param name="LastName">نام خانوادگی</param>
/// <param name="Email">پست الکترونیک</param>
/// <param name="PasswordHash">پسورد</param>
public record CreateUserCommand(string FirstName, string LastName, string Email, string PasswordHash) : IRequest<Guid>;