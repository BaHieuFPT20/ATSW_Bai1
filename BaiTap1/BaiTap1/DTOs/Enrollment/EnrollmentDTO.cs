using BaiTap1.Models;
using BaiTap1.DTOs.Student;
using BaiTap1.DTOs.Course;
namespace BaiTap1.DTOs.Enrollment
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public string Grade { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
    }
}
