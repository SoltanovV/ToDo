namespace AspBackend.Models.Entity.Responce;

public class CreateTodoResponce
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int Id { get; set; }

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
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата завершения задачи
    /// </summary>
    public DateTime EndDate { get; set; }

}
