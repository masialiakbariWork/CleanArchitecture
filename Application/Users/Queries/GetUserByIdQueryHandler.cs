using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Users.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// اطلاعات کاربر درخواستی را بر می گرداند
    /// </summary>
    /// <param name="request">درخواست دریافت کاربر بر اساس شناسه</param>
    /// <param name="cancellationToken"></param>
    /// <returns>کاربر</returns>
    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.Id);
    }
}