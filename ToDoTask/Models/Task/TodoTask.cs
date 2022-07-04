using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.Task
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class TodoTask
    {
        [Key]
        /// <summary>
        /// Id Задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string NameTask { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата постановки задачи
        /// </summary>
        public DateTime StartData { get; set; }

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime EndData { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Кто создал задачу
        /// </summary>
        public User CreateUser { get; set; } 

        /// <summary>
        /// Выполняющий задачи (может быть Null т.к. это может быть общая задача)
        /// </summary>
        public User? Responsible { get; set; }

        /// <summary>
        /// Id статуса
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        public TodoStatus? Status { get; set; }

    }
}
