namespace AspBackend.Models.Entity ;


    /// <summary>
    /// аккаунт пользователя
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int Id { get; set; }

        ///// <summary>
        ///// Токен пользователя
        ///// </summary>
        //public required string Token { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Навигационное свойство для UserProject
        /// </summary>
        public IEnumerable<UserProject>? UserProject { get; set; }

        /// <summary>
        /// Навигационное свойство для Project
        /// </summary>
        public IEnumerable<Project>? Projects { get; set; }

        /// <summary>
        /// Навигационное свойство для UserTodo
        /// </summary>
        public IEnumerable<UserTodo>? UserTodo { get; set; }

        /// <summary>
        /// Навигационное свойство для Todo
        /// </summary>
        public IEnumerable<Todo>? Todos { get; set; }
    }