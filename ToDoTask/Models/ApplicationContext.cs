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
        public DbSet<Priority> Priority { get; set; }
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
            //var account1 = new Account()
            //{
            //    Id = 1,
            //    Token = "sdasdsads",
            //    Login = "Влад",
            //    Password = "dsds23as",
            //    UserId = 1,
            //};
            //var accounts = new List<Account>()
            //{
            //    account1
            //};
            #endregion

            #region Заполнение User
            var user1 = new User()
            {
                Id = 1,
                Name = "dsds",
                Email = "dsdsd",
                ProjectId = 1,
                TodoId = 1
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

            #region Заполнение Priority
            var priority1 = new Priority()
            {
                Id = 1,
                PriorityName = "Срочно",

            };
            var priority2 = new Priority()
            {
                Id = 2,
                PriorityName = "В обычном темпе",
            };
            var priority3 = new Priority()
            {
                Id = 3,
                PriorityName = "Можно не торопиться",

            };

            var priorities = new List<Priority>()
            {
                priority1, priority2, priority3
            };
            #endregion

            #region Заполнение Status
            var status1 = new Status()
            {
                Id = 1,
                StatusName = "В ожидании"

            };
            var status2 = new Status()
            {
                Id = 2,
                StatusName = "В работе"
            };
            var status3 = new Status()
            {
                Id = 3,
                StatusName = "Завершено"
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
                ProjectId = 1,
                EndData = new DateTime(2077, 01, 01),
                StatusId = 1,
                UserId = 1,
                PriorityId = 1
            };

            var todo2 = new Todo()
            {
                Id = 2,
                NameTask = "хуй",
                Description = "dsdsd",
                ProjectId = 1,
                EndData = new DateTime(2077, 01, 01),
                StatusId = 1,
                UserId = 1,
                PriorityId = 1
            };

            var todos = new List<Todo>()
            {
                todo1, todo2
            };
            #endregion

           // modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Priority>().HasData(priorities);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Todo>().HasData(todos);


            // Создание связей 1 к 1 для Account и User
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<Account>(a => a.UserId);

            // Создание связей 1 ко многим для Project и User
            modelBuilder.Entity<Project>()
                .HasMany(p => p.User)
                .WithMany(u => u.Project);

            // Создание связей многие ко многим для Project и Todo
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Todo)
                .WithMany(t => t.Project);

            // Создание связей многие ко многим для Todo и Status
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Todo)
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<Todo>()
                .HasMany(t => t.User)
                .WithMany(u => u.Todo);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Priority)
                .WithMany(p => p.Todo)
                .HasForeignKey(t => t.PriorityId);
        }

    }

}
