
using BaiTap1.DTOs.Course;
using BaiTap1.Models;

namespace BaiTap1.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO ToCourseDTO(Course course) {
            return new CourseDTO
            {
                CourseID = course.CourseID,
                Credits = course.Credits,
                Title = course.Title
            };
            }
        public static Course ToCourseFromCreateCourseDTO(CreateCourseDTO createCourseDTO)
        {
            return new Course
            {
                Credits = createCourseDTO.Credits,
                Title = createCourseDTO.Title
            };
        }
        public static Course ToCourseFromUpdateCourseDTO(UpdateCourseDTO updateCourseDTO) {
            return new Course
            {
                Credits = updateCourseDTO.Credits,
                Title = updateCourseDTO.Title
            }; 
        }
    }

}
