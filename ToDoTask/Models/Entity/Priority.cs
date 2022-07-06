namespace ToDoTaskServer.Models.Entity
{
    /// <summary>
    /// Статус задачи
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
        public string PriorityName { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int TodoId { get; set; }
        /// <summary>
        /// Навигационное свойство для Task
        /// </summary>
        public IEnumerable<Todo> Todo { get; set; }
    }
}
