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
            Database.EnsureCreated();
        }

        //TODO: Настроить связи
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   // modelBuilder.Entity<TodoTask>()
        //        //.HasOne(t => t.Status)
        //        //.WithOne(i => i.StatusId)
        //       // .HasForeignKey(i => i.StatusId);
        //}
    }
}
