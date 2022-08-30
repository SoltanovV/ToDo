using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspBackend.Models.Entity
{
    /// <summary>
    /// аккаунт пользователя
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Токен пользователя
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Логин аккаунта
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        public User? User { get; set; }
    }
}
