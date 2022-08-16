using ASPbackend.Models.Entity;
using System.Text.Json.Serialization;

namespace AspBackend.Models.Entity
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Навигационное свойство для UserProject
        /// </summary>
        [JsonIgnore]
        public IEnumerable<UserProject> UserProject { get; set; }

        /// <summary>
        /// Навигационное свойство для Project
        /// </summary>
        public IEnumerable<Project> Projects { get; set; }

        /// <summary>
        /// Внешний ключ для Account
        /// </summary>
        [JsonIgnore]
        public int AccountId { get; set; }

        /// <summary>
        /// Навигационное свойство Account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Навигационное свойство для UserTodo
        /// </summary>
        [JsonIgnore]
        public IEnumerable<UserTodo> UserTodo { get; set; }

        /// <summary>
        /// Навигационное свойство для Todo
        /// </summary>
        public IEnumerable<Todo> Todos { get; set; }
    }
}
