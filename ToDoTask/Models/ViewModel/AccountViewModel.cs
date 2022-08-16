namespace AspBackend.Models.ViewModel
{
    public class AccountViewModel
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Токен акканута
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Внешний ключ для Todo
        /// </summary>
        public int UserId { get; set; }
    }
}
