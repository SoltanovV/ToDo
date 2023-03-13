namespace Models.Request ;

    public class UserAuthorizationRequest
    {
        /// <summary>
        /// Токен пользователя
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// Логин аккаунта
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        public required string Password { get; set; }
    }