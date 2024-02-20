

using FacultySystem.Data.Enteties;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem.Infrastructure.ApplicationContext
{
    public class FacultyDbContext : DbContext
    {
        public FacultyDbContext()
        {

        }
        public FacultyDbContext(DbContextOptions<FacultyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentSubject>().HasKey(
                StudSubj =>
                new { StudSubj.StudentId, StudSubj.SubjectId });
            builder.Entity<DepartmentSubject>().HasKey(
                DeptSubj =>
                new { DeptSubj.DepartmentId, DeptSubj.SubjectId });

            builder.Entity<InstructorSubjects>().HasKey(
                InstSubj =>
                new { InstSubj.InstructorId, InstSubj.SubjectId });

            builder.Entity<Instructor>().HasOne(ins => ins.Supervisor).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Department>().HasOne(dept => dept.InstructorManager).WithOne().HasForeignKey<Department>(dep => dep.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Department>().HasMany(dept => dept.Students).WithOne(st => st.Department).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Department>().HasMany(dept => dept.Subjects).WithOne(sub => sub.Department).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Department>().HasMany(dept => dept.Instructors).WithOne(ins => ins.Department).OnDelete(DeleteBehavior.Restrict);





        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        //  public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        // public DbSet<InstructorSubjects> InstructorSubjects { get; set; }


    }
}
