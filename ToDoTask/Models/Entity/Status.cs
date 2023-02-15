namespace AspBackend.Models.Entity;

/// <summary>
/// Статус задачи
/// </summary>
public class Status
{
    /// <summary>
    /// Id статуса
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    public StatusType StatusName { get; set; } = StatusType.Pending;

    /// <summary>
    /// Навигационное свойство для Task
    /// </summary>
    public IEnumerable<Todo> Todo { get; set; }
}

/// <summary>
/// Тип статуса задачи
/// </summary>
public enum StatusType
{
    /// <summary>
    /// В ожидании
    /// </summary>
    Pending = 0,

    /// <summary>
    /// Выполняется
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// Поставлена на паузу
    /// </summary>
    Pause = 2,

    /// <summary>
    /// Завершена
    /// </summary>
    Completed = 3
}