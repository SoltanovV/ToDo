namespace ToDoTaskServer.Models.ViewModel
{
    public class ProjectViewModel
    {
        /// <summary>
        /// Id Проекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Название проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата начала(создания)
        /// </summary>
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата сдачи проекта
        /// </summary>
        public DateTime DeadLine { get; set; }

        public int UserId { get; set; }

        public int TodoId { get; set; }
    }
}
