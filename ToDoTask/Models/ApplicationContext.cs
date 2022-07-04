using Microsoft.EntityFrameworkCore;
using ToDoTask.Models.Task;

namespace ToDoTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<TodoTask> TodoTask { get; set; }
        public DbSet<TodoStatus> Statuse { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new User()
            {
                Id = 1,
                Name = "Владислав",
                Login = "dsdsd",
                Password = "dsdsds"

            };
            var user2 = new User()
            {
                Id = 2,
                Name = "Софка",
                Login = "выфцы",
                Password = "вы2а3"

            };
            var user3 = new User()
            {
                Id = 3,
                Name = "Максимка",
                Login = "32323ык",
                Password = "ывыва334"

            };

            var users = new List<User>()
            {
                user1,
                user2,
                user3
            };

            var todoStatus1 = new TodoStatus()
            {
                Id = 1,
                Status = "хуйня"
            };
            var todoStatus2 = new TodoStatus()
            {
                Id = 2,
                Status = "залупа"
            };
            var todoStatus3 = new TodoStatus()
            {
                Id = 3,
                Status = "пизда"
            };

            var todoStatus = new List<TodoStatus>()
            {
                todoStatus1,
                todoStatus2,
                todoStatus3
            };

            var todo1 = new TodoTask()
            {
                Id = 1,
                NameTask = "Подзалуповик",
                Description = "тесет хуйни",
                StatusId = 2,
                UserId = 1,
                StartData = DateTime.Today,
                EndData = new DateTime(2077, 01, 01),
            };
            var todo2 = new TodoTask()
            {
                Id = 2,
                NameTask = "хуй",
                Description = "хуйни",
                StatusId = 1,
                UserId = 3,
                StartData = DateTime.Today,
                EndData = new DateTime(2077, 01, 01),
            };

            var todo = new List<TodoTask>
            {
                todo1,
                todo2
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<TodoStatus>().HasData(todoStatus);
            modelBuilder.Entity<TodoTask>().HasData(todo);

            // Создание связей между таблицами
            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Todo)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.CreateUser)
                .WithMany(u => u.Todos)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);
           
        }



    }
}
