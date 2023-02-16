namespace AspBackend.Models.Entity.Responce;

/// <summary>
/// аккаунт пользователя
/// </summary>
public class SigInResponce
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
    public required string Login { get; set; }

    /// <summary>
    /// Пароль аккаунта
    /// </summary>
    public required string Password { get; set; }

}
