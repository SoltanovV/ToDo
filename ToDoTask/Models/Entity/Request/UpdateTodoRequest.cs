namespace AspBackend.Models.Entity.Request;

public class UpdateTodoRequest
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    public required int StatusId { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    public required int PriorityId { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    public required string NameTask { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Дата завершения задачи
    /// </summary>
    public DateTime EndDate { get; set; }

}
