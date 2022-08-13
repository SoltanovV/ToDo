using ASPbackend.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
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
            var account1 = new Account()
            {
                Id = 1,
                Token = "sdasdsads",
                Login = "Влад",
                Password = "dsds23as",
                Email = "sdsds@h",
                
                
            };
            var account2 = new Account()
            {
                Id = 2,
                Token = "dfsdsds23jk44k56l6j46j45k234345345345l3",
                Login = "Софка",
                Password = "sf324gfg9dgdfhask3m3n423",
                Email = "sdsds@h",


            };
            var account3 = new Account()
            {
                Id = 3,
                Token = "dcervrt34gfv3fdcv234d",
                Login = "Максим",
                Password = "dsds2вывфаыаывпdf4e3as",
                Email = "sdsds@h",


            };
            var accounts = new List<Account>()
            {
                account1, account2, account3
            };
            #endregion

            #region Заполнение UserProject
            var up1 = new UserProject()
            {
                ProjectId = 1,
                UserId = 1
            };
            var up2 = new UserProject()
            {
                ProjectId = 1,
                UserId = 2
            };
            var up3 = new UserProject()
            {
                ProjectId = 1,
                UserId = 3
            };

            var userProject = new List<UserProject>()
            {
                up1,up2, up3
            };
            #endregion

            #region Заполнение User
            var user1 = new User()
            {
                Id = 1,
                Name = "Влад",
                AccountId =1,
                
            };
            var user2 = new User()
            {
                Id = 2,
                Name = "Софка",
                AccountId = 2,
            };
            var user3 = new User()
            {
                Id = 3,
                Name = "Максим",
                AccountId = 3,
            };
            var users = new List<User>()
            {
                user1, user2, user3
            };
            #endregion

            #region Заполнение UserTodo
            var ut1 = new UserTodo()
            {
               UserId=1,
               TodoId = 1,
            };
            var ut2 = new UserTodo()
            {
                UserId = 2,
                TodoId = 2,
            };
            var ut3 = new UserTodo()
            {
                UserId = 3,
                TodoId = 1,
            };

            var ut4 = new UserTodo()
            {
                UserId = 2,
                TodoId = 4,
            };

            var userTodo = new List<UserTodo>()
            {
                ut1,ut2, ut3, ut4
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

            #region Заполнение Project
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                DeadLine = new DateTime(2078, 01, 01)
            };
            var projects = new List<Project>()
            {
                project1
            };
            #endregion

            #region Заполнение ProjectTodo
            var pt1 = new ProjectTodo()
            {
                ProjectId = 1,
                TodoId = 1
            };

            var pt2 = new ProjectTodo()
            {
                ProjectId = 1,
                TodoId = 2
            };

            var pt3 = new ProjectTodo()
            {
                ProjectId = 1,
                TodoId = 3
            };

            var projectTodo = new List<ProjectTodo>()
            {
                pt1, pt2, pt3
            };
            #endregion

            #region Заполнение Todo
            var todo1 = new Todo()
            {
                Id = 1,
                NameTask = "Доделать БД и связи",
                Description = "Срочно доделать БД",
                EndData = new DateTime(2077, 01, 01),
                StatusId = 2,
                PriorityId = 1 

            };
            var todo2 = new Todo()
            {
                Id = 2,
                NameTask = "Доделать клиент",
                Description = "Доделать клиентскую часть на React",
                EndData = new DateTime(2077, 01, 01),
                StatusId = 2,
                PriorityId = 2

            };
            var todo3 = new Todo()
            {
                Id = 3,
                NameTask = "Залить проект на сервер",
                Description = "dsdsd",
                EndData = new DateTime(2077, 01, 01),
                StatusId = 1,
                PriorityId = 3

            };

            var todo4 = new Todo()
            {
                Id = 4,
                NameTask = "Нарисовать дизайн",
                Description = "Срочно доделать БД",
                EndData = new DateTime(2077, 01, 01),
                StatusId = 2,
                PriorityId = 1

            };

            var todos = new List<Todo>()
            {
                todo1, todo2, todo3, todo4
            };
            #endregion

            modelBuilder.Entity<UserTodo>().HasData(userTodo);
            modelBuilder.Entity<ProjectTodo>().HasData(projectTodo);
            modelBuilder.Entity<UserProject>().HasData(userProject);

            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Priority>().HasData(priorities);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Todo>().HasData(todos);


            //Создание связей 1 к 1 для Account и User
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountId);

            // Создание связей многие ко многим для Project и Todo
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Todos)
                .WithMany(t => t.Projects)
                .UsingEntity<ProjectTodo>(
                j => j
                    .HasOne(pt => pt.Todo)
                    .WithMany(t => t.ProjectTodo)
                    .HasForeignKey(pt => pt.TodoId),
                j => j
                    .HasOne(pt => pt.Project)
                    .WithMany(p => p.ProjectTodo)
                    .HasForeignKey(pt => pt.ProjectId),
                j => j
                    .HasKey(pt => new { pt.ProjectId, pt.TodoId })
                 );


            // Создание связей многие ко многим для Project и User
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Projects)
                .UsingEntity<UserProject>(
                j => j
                    .HasOne(up => up.User)
                    .WithMany(u => u.UserProject)
                    .HasForeignKey(up => up.UserId),

                j => j
                    .HasOne(up => up.Project)
                    .WithMany(p => p.UserProject)
                    .HasForeignKey(up => up.ProjectId),
                j => j.HasKey(up => new { up.ProjectId, up.UserId })
                );

            // Создание связей многие ко многим для User и Todo
            modelBuilder.Entity<User>()
                    .HasMany(u => u.Todos)
                    .WithMany(t => t.Users)
                    .UsingEntity<UserTodo>(
                j => j
                    .HasOne(ut => ut.Todo)
                    .WithMany(t => t.UserTodo)
                    .HasForeignKey(ut => ut.TodoId),
                j => j
                    .HasOne(ut => ut.User)
                    .WithMany(u => u.UserTodo)
                    .HasForeignKey(ut => ut.UserId),
                j => j.HasKey(up => new {up.UserId, up.TodoId })
                );

            // Создание связей многие ко многим для Todo и Status
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Todo)
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Priority)
                .WithMany(p => p.Todo)
                .HasForeignKey(t => t.PriorityId);



        }

    }

}
