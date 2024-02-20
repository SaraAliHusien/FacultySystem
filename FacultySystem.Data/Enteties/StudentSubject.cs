
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class StudentSubject
    {
        [Column(Order = 0), Key, ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public decimal? Grade { get; set; }
        public virtual Student Student { get; set; } = default!;
        public virtual Subject Subject { get; set; } = default!;

    }
}
