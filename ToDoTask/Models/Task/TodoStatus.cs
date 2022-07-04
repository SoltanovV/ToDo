using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.Task
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class TodoStatus
    {
        [Key]
        /// <summary>
        /// Id статуса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Задачи у которых есть статус
        /// </summary>
        public List<TodoTask>? Todo { get; set; }
    }
}
