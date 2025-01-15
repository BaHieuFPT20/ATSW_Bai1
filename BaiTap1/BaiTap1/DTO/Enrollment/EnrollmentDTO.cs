using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap1.DTO.Enrollment
{
    public class EnrollmentDTO
    {
        [Key]
        public int enrollmentid { get; set; }

        // Khóa ngoại liên kết với Course
        [ForeignKey("course")]
        public int courseid { get; set; }

        // Khóa ngoại liên kết với Student
        [ForeignKey("student")]
        public int studentid { get; set; }

        public string grade { get; set; }
    }
}
