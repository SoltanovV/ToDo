namespace ToDoTaskServer.Models.Entity
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Id статуса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя статуса
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Навигационное свойство для Task
        /// </summary>
        public IEnumerable<Todo> Todo { get; set; }
    }
}
