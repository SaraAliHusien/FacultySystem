using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class DepartmentSubject
    {
        [Column(Order = 0), Key, ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Department Department { get; set; } = default!;
        public virtual Subject Subject { get; set; } = default!;
    }
}