using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        // Quan hệ 1 - N với Enrollment
        public ICollection<Enrollment> Enrollments { get; set; }

        //public Student() { }
        //public Student(int iD, string lastName, string firstMidName, DateTime enrollmentDate, ICollection<Enrollment> enrollments)
        //{
        //    ID = iD;
        //    LastName = lastName;
        //    FirstMidName = firstMidName;
        //    EnrollmentDate = enrollmentDate;
        //    Enrollments = enrollments;
        //}
    }
}
