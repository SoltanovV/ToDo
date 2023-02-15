namespace AspBackend.Models.Entity.Request;

/// <summary>
/// Пользователь
/// </summary>
public class UserRequest
{

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Email аккаунта
    /// </summary>
    public required string Email { get; set; }


}
