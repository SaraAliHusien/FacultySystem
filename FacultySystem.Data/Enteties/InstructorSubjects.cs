using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class InstructorSubjects
    {
        [Column(Order = 0), Key, ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }
        [Column(Order = 1), Key, ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public virtual Instructor Instructor { get; set; } = default!;
        public virtual Subject Subject { get; set; } = default!;
    }
}
