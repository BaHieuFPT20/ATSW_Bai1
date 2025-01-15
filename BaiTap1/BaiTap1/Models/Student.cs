using System.ComponentModel.DataAnnotations;

namespace BaiTap1.Models
{
    public class student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string firstmidname { get; set; }

        [DataType(DataType.Date)]
        public DateTime enrollmentdate { get; set; }

        // Quan hệ 1 - N với Enrollment
        public ICollection<enrollment> enrollments { get; set; }
    }
}
