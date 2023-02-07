using System.Text.Json.Serialization;

namespace AspBackend.Models.Entity;

/// <summary>
/// Задачи
/// </summary>
public class Todo
{
    /// <summary>
    /// Id Задачи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    public string NameTask { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Дата постановки задачи
    /// </summary>
    public DateTime StartDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата завершения задачи
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Навигационное свойство для UserTodo
    /// </summary>
    [JsonIgnore]
    public IEnumerable<UserTodo> UserTodo { get; set; }

    /// <summary>
    /// Навигационное свойство для User
    /// </summary>
    
    public IEnumerable<User> Users { get; set; }

    /// <summary>
    /// Внешний ключ для Status
    /// </summary>
    [JsonIgnore]
    public int StatusId { get; set; }

    /// <summary>
    /// Навигационное свойство для Status
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Внешний ключ для Priority
    /// </summary>
    [JsonIgnore]
    public int PriorityId { get; set; }

    /// <summary>
    /// Навигационное свойство для Priority
    /// </summary>
    public Priority Priority { get; set; }

    /// <summary>
    /// Навигационное свойство для ProjectTodo
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ProjectTodo> ProjectTodo { get; set; }

    /// <summary>
    /// Навигационное свойство для Project
    /// </summary>
    public IEnumerable<Project> Projects { get; set; }
}

