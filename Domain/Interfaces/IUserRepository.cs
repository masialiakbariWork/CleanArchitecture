using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// دریافت لیست تمام کاربران
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<User>> GetAllAsync();
    /// <summary>
    /// دریافت کابر بر اساس شناسه
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(Guid id);
    /// <summary>
    /// افزودن کاربر
    /// </summary>
    /// <param name="newUser">کاربر جدید</param>
    /// <returns></returns>
    Task AddAsync(User newUser);
    /// <summary>
    /// اصلاح کاربر
    /// </summary>
    /// <param name="user">اطلاعات کاربر</param>
    /// <returns></returns>
    Task UpdateAsync(User user);
    /// <summary>
    /// حذف کاربر
    /// </summary>
    /// <param name="id">شناسه ی کاربری که باید حذف شود</param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);
}
