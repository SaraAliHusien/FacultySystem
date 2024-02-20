﻿// <auto-generated />
using System;
using FacultySystem.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FacultySystem.Infrastracture.Migrations
{
    [DbContext(typeof(FacultyDbContext))]
    [Migration("20240215030152_instructorsUpdate")]
    partial class instructorsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FacultySystem.Data.Enteties.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.DepartmentSubject", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("DepartmentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("DepartmentSubjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SupervisorId")
                        .IsUnique();

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.InstructorSubjects", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("InstructorId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("InstructorSubjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("StudentId");

                    b.HasIndex("DId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Department", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Instructor", "InstructorManager")
                        .WithOne()
                        .HasForeignKey("FacultySystem.Data.Enteties.Department", "ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InstructorManager");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.DepartmentSubject", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultySystem.Data.Enteties.Subject", "Subject")
                        .WithMany("Departments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Instructor", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultySystem.Data.Enteties.Instructor", "Supervisor")
                        .WithOne()
                        .HasForeignKey("FacultySystem.Data.Enteties.Instructor", "SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.InstructorSubjects", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Instructor", "Instructor")
                        .WithMany("Subjects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultySystem.Data.Enteties.Subject", "Subject")
                        .WithMany("Instructors")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Student", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.StudentSubject", b =>
                {
                    b.HasOne("FacultySystem.Data.Enteties.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultySystem.Data.Enteties.Subject", "Subject")
                        .WithMany("Students")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Instructor", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Student", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("FacultySystem.Data.Enteties.Subject", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
