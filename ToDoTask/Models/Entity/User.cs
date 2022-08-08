using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoTaskServer.Models.Entity
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
        /// Внешний ключ для Account
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Навигационное свойство Account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Внешний ключ для Account
        /// </summary>
        [JsonIgnore]
        public int AccountId { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>

        public Account Account { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        
        public IEnumerable<Project> Project { get; set; }

        /// <summary>
        /// Внешний ключ для Todo
        /// </summary>
        [JsonIgnore]
        public int TodoId { get; set; }

        /// <summary>
        /// Навигационное свойство для Todo
        /// </summary>
        
        public IEnumerable<Todo> Todo { get; set; }
    }
}
