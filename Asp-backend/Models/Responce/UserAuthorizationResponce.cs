namespace Models.Responce;

public class UserAuthorizationResponce
{
    public int Id { get; set; } 

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Токен пользователя
    /// </summary>
    public required string Token { get; set; }
}
