namespace AspBackend.Models.Entity.Responce;

public class UpdateTodoResponce
{
    /// <summary>
    /// Id задачи
    /// </summary>
    public int id { get; set; }

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
    /// Дата завершения задачи
    /// </summary>
    public DateTime EndDate { get; set; }
}
