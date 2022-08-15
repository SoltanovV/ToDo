using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public IEnumerable<Todo> Todo { get; set; }
    }
}
