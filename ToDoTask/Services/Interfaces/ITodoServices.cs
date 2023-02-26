namespace AspBackend.Services.Interfaces;

/// <summary>
/// Интерфейс для работы с задачами
/// </summary>
public interface ITodoServices
{
    /// <summary>
    /// Создание задачи
    /// </summary>
    /// <param name="model">модель задачи</param>
    /// <returns></returns>
    public Task<Todo> CreateTodoAsync(Todo model);

    /// <summary>
    /// Обновление задачи
    /// </summary>
    /// <param name="model">модель задачи</param>
    /// <returns></returns>
    public Task<Todo> UpdateTodoAsync(Todo model);

    /// <summary>
    /// Удаление задачи
    /// </summary>
    /// <param name="id">Id задачи</param>
    /// <returns></returns>
    public Task<Todo> DeleteTodoAsync(int id);

    /// <summary>
    /// Добавление пользователя к задачи
    /// </summary>
    /// <param name="model">модель пользователя</param>
    /// <returns></returns>
    public Task<UserTodo> AddUserAsync(UserTodo model);

    /// <summary>
    /// Удаление пользователя с задачи
    /// </summary>
    /// <param name="model">модель пользователя</param>
    /// <returns></returns>
    public Task<UserTodo> DeleteUserAsync(UserTodo model);
}
