using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
    public Task<Todo> CreateTodo(Todo model);

    /// <summary>
    /// Обновление задачи
    /// </summary>
    /// <param name="model">модель задачи</param>
    /// <returns></returns>
    public Task<Todo> UpdateTodo(Todo model);

    /// <summary>
    /// Удаление задачи
    /// </summary>
    /// <param name="id">Id задачи</param>
    /// <returns></returns>
    public Task<Todo> DeleteTodo(int id);

    /// <summary>
    /// Добавление пользователя к задачи
    /// </summary>
    /// <param name="model">модель пользователя</param>
    /// <returns></returns>
    public Task<UserTodo> AddUser(UserTodo model);

    /// <summary>
    /// Удаление пользователя с задачи
    /// </summary>
    /// <param name="model">модель пользователя</param>
    /// <returns></returns>
    public Task<UserTodo> DeleteUser(UserTodo model);
}
