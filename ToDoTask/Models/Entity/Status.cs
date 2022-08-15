using System.Text.Json.Serialization;

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
        /// Навигационное свойство для Task
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Todo> Todo { get; set; }
    }
}
