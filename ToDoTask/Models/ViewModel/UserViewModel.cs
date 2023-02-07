namespace AspBackend.Models.ViewModel;

public class UserViewModel
{
    /// <summary>
    /// Внешний ключ для Project
    /// </summary>
    public int ProjectId { get; set; }

    /// <summary>
    /// Внешний ключ для Todo
    /// </summary>
    public int TodoId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; set; }

}
