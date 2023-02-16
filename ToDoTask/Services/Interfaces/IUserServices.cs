using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;

namespace AspBackend.Services.Interfaces;

/// <summary>
/// Интерфейс для работы с аккаунтом пользователя
/// </summary>
public interface IUserServices
{
    /// <summary>
    /// Создание аккаунта
    /// </summary>
    /// <param name="model">модель User</param>
    /// <returns></returns>
    public Task<Account> CreateAccount(AccountViewModel model);

    /// <summary>
    /// Изменения аккаунта
    /// </summary>
    /// <param name="model">модель User</param>
    /// <returns></returns>
    public Task<User> UpdateUser(UserViewModel model);

    /// <summary>
    /// Удаление аккаунта
    /// </summary>
    /// <param name="id">Id аккаунта</param>
    /// <returns></returns>
    public Task<User> DeleteUserAsync(int id);
}
