namespace AspBackend.Models.ViewModel
{
    public class TodoViewModel
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string NameTask { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата постановки задачи
        /// </summary>
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime EndData { get; set; }

        /// <summary>
        /// Внешний ключ для Priority
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Внешний ключ для Priority
        /// </summary>
        public int PriorityId { get; set; }

    }
}
