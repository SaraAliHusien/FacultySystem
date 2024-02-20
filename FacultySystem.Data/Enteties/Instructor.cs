using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public int? SupervisorId { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        public virtual Instructor? Supervisor { get; set; }


        //[InverseProperty(nameof(Supervisor))]
        //public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();


        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Instructors")]
        public virtual Department Department { get; set; }


        //[InverseProperty(nameof(FacultySystem.Data.Enteties.Department.InstructorManager))]
        //public virtual Department ManagementDepartment { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<InstructorSubjects> Subjects { get; set; } = new HashSet<InstructorSubjects>();

    }
}
