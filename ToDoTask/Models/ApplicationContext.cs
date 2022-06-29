using Microsoft.EntityFrameworkCore;

namespace ToDoTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
