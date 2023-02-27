namespace AspBackend.Services.Interface;

/// <summary>
/// Интерфейс для работы с проектами
/// </summary>
public interface IProjectServices
{
    /// <summary>
    /// Создание проекта
    /// </summary>
    /// <param name="model">входные данные с клиента</param>
    /// <returns></returns>
    public Task<Project> CreateProjectAsync(Project model);

    /// <summary>
    /// Обновление проекта
    /// </summary>
    /// <param name="model">входные данные с клиента</param>
    /// <returns></returns>
    public Task<Project> UpdateProjectAsync(Project model);

    /// <summary>
    /// Удаление проекта
    /// </summary>
    /// <param name="id">Id проекта</param>
    /// <returns></returns>
    public Task<Project> DeleteProjectAsync(int id);

    /// <summary>
    /// Добавление пользователя на проект
    /// </summary>
    /// <param name="model">сущность UserProject</param>
    /// <returns></returns>
    public Task<UserProject> AddUserProjectAsync(UserProject model);

    /// <summary>
    /// Удаление пользователя с проекта
    /// </summary>
    /// <param name="model">сущность UserProject</param>
    /// <returns></returns>
    public Task<UserProject> DeleteUserProjectAsync(UserProject model);
}
