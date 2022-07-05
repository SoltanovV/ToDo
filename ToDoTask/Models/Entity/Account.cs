using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTaskServer.Models.Entity
{
    /// <summary>
    /// аккаунт пользователя
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Токен акканута
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        
        public int UserId { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
