namespace BaiTap1.DTO.Course
{
    public class UpdateCourseDTO
    {
        public int courseid { get; set; }

        //[Required]
        //[StringLength(100)]
        public string title { get; set; }

        //[Range(1, 10)]
        public int credits { get; set; }
    }
}
