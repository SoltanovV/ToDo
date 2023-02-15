namespace AspBackend.Models.Entity;

/// <summary>
/// Приоритет задачи
/// </summary>
public class Priority
{
    /// <summary>
    /// Id статуса
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    public PriorityType PriorityName { get; set; } = PriorityType.Urgently;

    /// <summary>
    /// Навигационное свойство для Ещвщ
    /// </summary>
    public IEnumerable<Todo> Todo { get; set; }
}

/// <summary>
/// Тип приоритета задачи
/// </summary>
public enum PriorityType
{
    /// <summary>
    /// Срочно
    /// </summary>
    Urgently = 0,

    /// <summary>
    /// Выполняется
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// Медленно
    /// </summary>
    Slowly = 2,
}
