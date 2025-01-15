using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap1.DTO.Enrollment
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public string Grade { get; set; }
    }
}
