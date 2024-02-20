

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = default!;
        //public string DepartmentName { get; set; } = default!;
        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public virtual Instructor? InstructorManager { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<DepartmentSubject> Subjects { get; set; } = new HashSet<DepartmentSubject>();
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();




    }

}