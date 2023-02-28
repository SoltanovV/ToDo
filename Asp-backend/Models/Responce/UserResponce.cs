namespace Models.Responce;

/// <summary>
/// Пользователь
/// </summary>
public class UserResponce
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Email аккаунта
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Навигационное свойство для Project
    /// </summary>
    public required IEnumerable<Project> Projects { get; set; }

    /// <summary>
    /// Навигационное свойство для Todo
    /// </summary>
    public required IEnumerable<Todo> Todos { get; set; }
}
