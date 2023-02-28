namespace AspBackend.Models.Entity;

/// <summary>
/// Проект
/// </summary>
public class Project
{
    /// <summary>
    /// Id проекта
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///  Название проекта
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Дата начала(создания)
    /// </summary>
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата сдачи проекта
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Навигационное свойство для UserProject
    /// </summary>
    public required IEnumerable<UserProject> UserProject { get; set; }

    /// <summary>
    /// Навигационное свойство для User
    /// </summary>
    public required IEnumerable<Account> Accounts { get; set; }

    /// <summary>
    /// Навигационное свойство для ProjectTodo
    /// </summary>
    public required IEnumerable<ProjectTodo> ProjectTodo { get; set; }

    /// <summary>
    /// Навигационное свойство для Todo
    /// </summary>
    public required IEnumerable<Todo> Todos { get; set; }
}
