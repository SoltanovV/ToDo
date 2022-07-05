using Microsoft.EntityFrameworkCore;
using ToDoTaskServer.Models.Entity;

namespace ToDoTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Status> Status { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Заполнение Account
            var account1 = new Account()
            {
                Id = 1,
                Token = "sdasdsads",
                UserId = 1
            };

            var accounts = new List<Account>()
            {
                account1
            };
            #endregion

            #region Заполнение User
            var user1 = new User()
            {
                Id = 1,
                Name = "dsds",
                Email = "dsdsd",
                AccountId = 1,
                Password = "вывывы",
                ProjectId = 1
            };
            var users = new List<User>()
            {
                user1
            };
            #endregion

            #region Заполнение Project
            var project1 = new Project()
            {
                Id = 1,
                Name = "пизда",
                DeadLine = new DateTime(2078, 01, 01),
                TodoId = 1,
                UserId = 1
            };
            var projects = new List<Project>()
            {
                project1
            };
            #endregion

            #region Заполнение Status
            var status1 = new Status()
            {
                Id = 1,
                StatusName = "Срочно",

            };
            var status2 = new Status()
            {
                Id = 2,
                StatusName = "В обычном темпе",

            };
            var status3 = new Status()
            {
                Id = 3,
                StatusName = "Можно не торопиться",

            };

            var statuses = new List<Status>()
            {
                status1, status2, status3
            };
            #endregion

            #region Заполнение Todo

            var todo1 = new Todo()
            {
                Id = 1,
                NameTask = "хуй",
                Description = "dsdsd",
                ProjectsId = 1,
                EndData = new DateTime(2077, 01, 01),
                StatusId = 1,
                UserId = 1,
            };

            var todos = new List<Todo>()
            {
                todo1
            };
            #endregion

            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Todo>().HasData(todos);


            // Создание связей 1 к 1 для Account и User
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account);

            // Создание связей 1 ко многим для Project и User
            modelBuilder.Entity<Project>()
                .HasMany(p => p.User)
                .WithOne(u => u.Project);

            // Создание связей многие ко многим для Project и Todo
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Todo)
                .WithMany(t => t.Project);

            // Создание связей многие ко многим для Todo и Status
            modelBuilder.Entity<Todo>()
                .HasMany(t => t.Statuse)
                .WithMany(s => s.Todo);

        }

    }

}
