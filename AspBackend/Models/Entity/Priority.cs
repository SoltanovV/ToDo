namespace AspBackend.Models.Entity ;

    /// <summary>
    /// Приоритет задачи
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// Id статуса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя статуса
        /// </summary>
        public required string PriorityName { get; set; }

        /// <summary>
        /// Навигационное свойство для Ещвщ
        /// </summary>
        public required IEnumerable<Todo> Todo { get; set; }
    }