namespace Models.Responce;

/// <summary>
/// Модель для добавления 
/// </summary>
public class UserTodoResponce
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Id задачи
    /// </summary>
    public int TodoId { get; set; }
}
