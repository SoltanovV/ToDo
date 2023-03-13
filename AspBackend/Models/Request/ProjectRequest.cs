namespace Models.Request ;

    public class ProjectRequest
    {
        public int Id { get; set; }

        /// <summary>
        ///  Название проекта
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Дата начала(создания)
        /// </summary>
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата сдачи проекта
        /// </summary>
        public DateTime DeadLine { get; set; }
    }