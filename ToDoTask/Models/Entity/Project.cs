using System.Text.Json.Serialization;

namespace AspBackend.Models.Entity
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id проекта
        /// </summary>
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
        /// Навигационное свойство для UserProject
        /// </summary>
        [JsonIgnore]
        public IEnumerable<UserProject> UserProject { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        public IEnumerable<User> Users { get; set; }

        /// <summary>
        /// Навигационное свойство для ProjectTodo
        /// </summary>
        public IEnumerable<ProjectTodo> ProjectTodo { get; set; }

        /// <summary>
        /// Навигационное свойство для Todo
        /// </summary>
        public IEnumerable<Todo> Todos { get; set; }
    }
}
