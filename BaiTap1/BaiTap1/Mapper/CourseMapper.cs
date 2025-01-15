using BaiTap1.DTO.Course;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class CourseMapper
    {
        public static CourseDTO ToCourseDTO(this course courseModel)
        {
            return new CourseDTO
            {
                courseid = courseModel.courseid,
                title = courseModel.title,
                credits = courseModel.credits
            };
        }

        public static course ToCourseFromDTO(this CreateCourseDTO courseDto)
        {
            return new course
            {
                title = courseDto.title,
                credits = courseDto.credits
            };
        }

        public static course ToCourseFromDTO(this UpdateCourseDTO courseDto)
        {
            return new course
            {
                courseid = courseDto.courseid,
                title = courseDto.title,
                credits = courseDto.credits
            };
        }
    }
}
