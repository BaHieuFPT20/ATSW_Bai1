using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class enrollment
    {
        [Key]
        public int enrollmentid { get; set; }

        // Khóa ngoại liên kết với Course
        [ForeignKey("Course")]
        public int courseid { get; set; }

        // Khóa ngoại liên kết với Student
        [ForeignKey("Student")]
        public int studentid { get; set; }

        public string grade { get; set; }

        // Thuộc tính điều hướng (Navigation Properties)
        public course course { get; set; }
        public student student { get; set; }
    }
}
