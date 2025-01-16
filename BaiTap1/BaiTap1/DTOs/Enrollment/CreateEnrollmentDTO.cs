using BaiTap1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTap1.DTOs.Enrollment
{
    public class CreateEnrollmentDTO
    {
        public string Grade { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
