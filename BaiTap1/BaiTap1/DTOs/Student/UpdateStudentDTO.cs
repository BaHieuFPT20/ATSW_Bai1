using System.ComponentModel.DataAnnotations;

namespace BaiTap1.DTOs.Student
{
    public class UpdateStudentDTO
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
