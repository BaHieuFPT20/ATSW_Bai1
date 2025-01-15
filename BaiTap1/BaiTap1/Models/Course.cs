using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class course
    {
        [Key]
        public int courseid { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [Range(1, 10)]
        public int credits { get; set; }

        // Quan hệ 1 - N với Enrollment
        public ICollection<enrollment> enrollments { get; set; }
    }
}
