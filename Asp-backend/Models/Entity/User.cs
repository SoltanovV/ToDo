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
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

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

    /// <summary>
    /// Навигационное свойство для UserProject
    /// </summary>
    public IEnumerable<UserProject>? UserProject { get; set; }

    /// <summary>
    /// Навигационное свойство для Project
    /// </summary>
    public IEnumerable<Project>? Projects { get; set; }

    /// <summary>
    /// Навигационное свойство для UserTodo
    /// </summary>
    public IEnumerable<UserTodo>? UserTodo { get; set; }

    /// <summary>
    /// Навигационное свойство для Todo
    /// </summary>
    public IEnumerable<Todo>? Todos { get; set; }
}
