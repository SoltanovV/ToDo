namespace ToDoTaskServer.Models.ViewModel
{
    public class TodoViewModel
    {
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
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime EndData { get; set; }
    }
}
