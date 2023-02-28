namespace Models.Request;

public class CreateTodoRequest
{
    /// <summary>
    /// Имя статуса
    /// </summary>
    public required string StatusName { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    public required string PriorityName { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    public required string NameTask { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Дата постановки задачи
    /// </summary>
    public DateTime StartDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата завершения задачи
    /// </summary>
    public DateTime EndDate { get; set; }

}
