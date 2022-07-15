namespace ToDoTaskServer.Models.ViewModel
{
    public class UserViewModel
    {
        /// <summary>
        /// Внешний ключ для Account
        /// </summary>
        public int AccountId { get; set; } = 1;
        /// <summary>
        /// Внешний ключ для Project
        /// </summary>
        public int ProjectId { get; set; } = 1;
        /// <summary>
        /// Внешний ключ для Todo
        /// </summary>
        public int TodoId { get; set; } = 1;
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
    }
}
