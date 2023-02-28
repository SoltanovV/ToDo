namespace AspBackend.Services.Interface;

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
    public Task<Account> CreateAccountAsync(User user);

    public Task<Account> AuthorizationAccountAsync(User user);

    public Task<Account> AuthorizationAccountAsync(int userId);

    /// <summary>
    /// Изменения аккаунта
    /// </summary>
    /// <param name="model">модель User</param>
    /// <returns></returns>
    public Task<User> UpdateUserAsync(User model);

    /// <summary>
    /// Удаление аккаунта
    /// </summary>
    /// <param name="id">Id аккаунта</param>
    /// <returns></returns>
    public Task<User> DeleteUserAsync(int id);
}
