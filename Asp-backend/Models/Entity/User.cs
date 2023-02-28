namespace AspBackend.Models.Entity;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Логин аккаунта
    /// </summary>
    public required string Login { get; set; }

    /// <summary>
    /// Пароль аккаунта
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// Email аккаунта
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Внешний ключ для Account
    /// </summary>
    public int? AccountId { get; set; }

    /// <summary>
    /// Навигационное свойство Account
    /// </summary>
    public required Account Account { get; set; }


}
