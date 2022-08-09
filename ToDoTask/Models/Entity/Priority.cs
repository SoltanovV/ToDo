using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTaskServer.Models.Entity
{
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
        public string PriorityName { get; set; }

        /// <summary>
        /// Навигационное свойство для Ещвщ
        /// </summary>
        public IEnumerable<Todo> Todo { get; set; }
    }
}
