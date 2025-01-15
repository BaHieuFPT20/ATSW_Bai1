using System.ComponentModel.DataAnnotations;

namespace BaiTap1.DTO.Student
{
    public class UpdateStudentDTO
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
    }
}
