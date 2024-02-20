namespace FacultySystem.Data.Enteties
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = default!;

        //public string SubjectNameAr { get; set; } = default!;
        public int Period { get; set; }
        public virtual ICollection<DepartmentSubject> Departments { get; set; } = new HashSet<DepartmentSubject>();

        public virtual ICollection<StudentSubject> Students { get; set; } = new HashSet<StudentSubject>();
        public virtual ICollection<InstructorSubjects> Instructors { get; set; } = new HashSet<InstructorSubjects>();




    }
}