namespace ToDoTask.Models.ViewModel
{
    /// <summary>
    /// Модель представления для User
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }    

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
