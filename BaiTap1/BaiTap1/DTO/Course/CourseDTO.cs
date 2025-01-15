using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BaiTap1.DTO.Course
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}
