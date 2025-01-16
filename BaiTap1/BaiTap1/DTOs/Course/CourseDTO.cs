using System.ComponentModel.DataAnnotations;

namespace BaiTap1.DTOs.Course
{
    public class CourseDTO
    {

        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }
    }
}
