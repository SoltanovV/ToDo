namespace AspBackend.Models.Entity.Request;

/// <summary>
/// аккаунт пользователя
/// </summary>
public class SigInRequest
{
    /// <summary>
    /// Токен пользователя
    /// </summary>
    public required string Token { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Логин аккаунта
    /// </summary>
    public required  string Login { get; set; }

    /// <summary>
    /// Email аккаунта
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Пароль аккаунта
    /// </summary>
    public required string Password { get; set; }

}
