namespace ToDoTask.Models.Task
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class TodoStatus
    {
        /// <summary>
        /// Id статуса
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }
    }
}
