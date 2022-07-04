using System.ComponentModel.DataAnnotations;
using ToDoTask.Models.Task;

namespace ToDoTask.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        [Key]
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        public IEnumerable<TodoTask>? Todos { get; set; }

    }
}
