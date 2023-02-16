namespace AspBackend.Models.Entity;

/// <summary>
/// аккаунт пользователя
/// </summary>
public class Account
{
    /// <summary>
    /// Id аккаунта
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Токен пользователя
    /// </summary>
    public required string Token { get; set; }

    /// <summary>
    /// Логин аккаунта
    /// </summary>
    public required string Login { get; set; } = string.Empty;

    /// <summary>
    /// Пароль аккаунта
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// Навигационное свойство для User
    /// </summary>
    public User User { get; set; }
}
