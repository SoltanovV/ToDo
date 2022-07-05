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
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Внешний ключ для Account
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Навигационное свойство Account
        /// </summary>
        [JsonIgnore]
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        /// <summary>
        /// Внешний ключ для Project
        /// </summary>
        public int ProjectId { get; set; }


        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
