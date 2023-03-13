namespace AspBackend.Models.Entity ;

    /// <summary>
    /// Задачи
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Id Задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public required string NameTask { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Дата постановки задачи
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Навигационное свойство для UserTodo
        /// </summary>
        public IEnumerable<UserTodo>? UserTodo { get; set; }

        /// <summary>
        /// Навигационное свойство для User
        /// </summary>
        public IEnumerable<Account>? Accounts { get; set; }

        /// <summary>
        /// Внешний ключ для Status
        /// </summary>
        public required int StatusId { get; set; }

        /// <summary>
        /// Навигационное свойство для Status
        /// </summary>
        public Status? Status { get; set; }

        /// <summary>
        /// Внешний ключ для Priority
        /// </summary>
        public int PriorityId { get; set; }

        /// <summary>
        /// Навигационное свойство для Priority
        /// </summary>
        public Priority? Priority { get; set; }

        /// <summary>
        /// Навигационное свойство для ProjectTodo
        /// </summary>
        public IEnumerable<ProjectTodo>? ProjectTodo { get; set; }

        /// <summary>
        /// Навигационное свойство для Project
        /// </summary>
        public IEnumerable<Project>? Projects { get; set; }
    }