namespace AspBackend.Models.Entity.Request;

/// <summary>
/// Модель для добавления 
/// </summary>
public class UserTodoRequest
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
