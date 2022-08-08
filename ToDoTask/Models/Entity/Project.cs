using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoTaskServer.Models.Entity
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id проекта
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///  Название проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата начала(создания)
        /// </summary>
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата сдачи проекта
        /// </summary>
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        public IEnumerable<User> User { get; set; }

        /// <summary>
        /// Внешний ключ для Todo
        /// </summary>
        public int TodoId { get; set; }

        /// <summary>
        /// Навигационное свойство для Todo
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Todo> Todo { get; set; }
    }
}
