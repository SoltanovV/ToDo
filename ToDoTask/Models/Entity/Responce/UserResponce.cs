namespace AspBackend.Models.Entity.Responce;

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
    public string Name { get; set; }

    /// <summary>
    /// Email аккаунта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Навигационное свойство для Project
    /// </summary>
    public IEnumerable<Project> Projects { get; set; }

    /// <summary>
    /// Навигационное свойство для Todo
    /// </summary>
    public IEnumerable<Todo> Todos { get; set; }
}
