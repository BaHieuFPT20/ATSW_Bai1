using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Range(1, 10)]
        public int Credits { get; set; }

        // Quan hệ 1 - N với Enrollment
        public ICollection<Enrollment> Enrollments { get; set; }

        public Course() { }
        public Course(int courseID, string title, int credits, ICollection<Enrollment> enrollments)
        {
            CourseID = courseID;
            Title = title;
            Credits = credits;
            Enrollments = enrollments;
        }
    }
   
}
