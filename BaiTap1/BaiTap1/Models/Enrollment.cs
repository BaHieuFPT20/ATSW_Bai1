using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        // Khóa ngoại liên kết với Course
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        // Khóa ngoại liên kết với Student
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public string Grade { get; set; }

        // Thuộc tính điều hướng (Navigation Properties)
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
