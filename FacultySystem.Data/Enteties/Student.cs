using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultySystem.Data.Enteties
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }


        [MaxLength(250)]
        public string StudentName { get; set; } = default!;

        [MaxLength(500)]
        public string Address { get; set; } = default!;
        [MaxLength(11)]
        public string Phone { get; set; } = default!;
        public int DId { get; set; }
        [ForeignKey("DId")]
        public virtual Department Department { get; set; } = default!;
        public virtual ICollection<StudentSubject> Subjects { get; set; } = new HashSet<StudentSubject>();

        //[MaxLength(250)]
        //public string StudentNameEn { get; set; } = default!;
        //[MaxLength(500)]

        //public string AddressAr { get; set; } = default!;

    }
}
