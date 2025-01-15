using BaiTap1.DTO.Course;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class CourseMP
    {
        public static CourseDTO toCourseDTO(this course courseModel)
        {
            return new CourseDTO
            {
                CourseID = courseModel.courseid,
                Title = courseModel.title,
                Credits = courseModel.credits
            };
        }
        public static course toCourseFormCreateCourseDTO(this CreateCourseDTO createCourseDTO)
        {
            return new course
            {
                title = createCourseDTO.Title,
                credits = createCourseDTO.Credits
            };
        }
        public static course toCourseFormUpdateCourseDTO(this UpdateCourseDTO updateCourseDTO)
        {
            return new course
            {
                courseid = updateCourseDTO.CourseID,
                title = updateCourseDTO.Title,
                credits = updateCourseDTO.Credits
            };
        }
    }
}
