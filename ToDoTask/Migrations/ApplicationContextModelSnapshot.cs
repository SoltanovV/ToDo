﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoTask.Models;

#nullable disable

namespace ToDoTaskServer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectTodo", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "TodoId");

                    b.HasIndex("TodoId");

                    b.ToTable("ProjectTodo");
                });

            modelBuilder.Entity("StatusTodo", b =>
                {
                    b.Property<int>("StatuseId")
                        .HasColumnType("int");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("StatuseId", "TodoId");

                    b.HasIndex("TodoId");

                    b.ToTable("StatusTodo");
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Account", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Token = "sdasdsads",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartData")
                        .HasColumnType("datetime2");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeadLine = new DateTime(2078, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "пизда",
                            StartData = new DateTime(2022, 7, 5, 20, 38, 52, 644, DateTimeKind.Local).AddTicks(3908),
                            TodoId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Срочно",
                            TaskId = 0
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "В обычном темпе",
                            TaskId = 0
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Можно не торопиться",
                            TaskId = 0
                        });
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndData")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameTask")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartData")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Todo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "dsdsd",
                            EndData = new DateTime(2077, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NameTask = "хуй",
                            ProjectsId = 1,
                            StartData = new DateTime(2022, 7, 5, 20, 38, 52, 644, DateTimeKind.Local).AddTicks(3930),
                            StatusId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TodoId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Email = "dsdsd",
                            Name = "dsds",
                            Password = "вывывы",
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("ProjectTodo", b =>
                {
                    b.HasOne("ToDoTaskServer.Models.Entity.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoTaskServer.Models.Entity.Todo", null)
                        .WithMany()
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StatusTodo", b =>
                {
                    b.HasOne("ToDoTaskServer.Models.Entity.Status", null)
                        .WithMany()
                        .HasForeignKey("StatuseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoTaskServer.Models.Entity.Todo", null)
                        .WithMany()
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Account", b =>
                {
                    b.HasOne("ToDoTaskServer.Models.Entity.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("ToDoTaskServer.Models.Entity.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.User", b =>
                {
                    b.HasOne("ToDoTaskServer.Models.Entity.Project", "Project")
                        .WithMany("User")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoTaskServer.Models.Entity.Todo", null)
                        .WithMany("Users")
                        .HasForeignKey("TodoId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Project", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.Todo", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ToDoTaskServer.Models.Entity.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
