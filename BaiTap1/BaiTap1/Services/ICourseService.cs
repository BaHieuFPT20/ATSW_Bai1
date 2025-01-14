using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseByIdAsync(int courseId, Course course);
        Task<bool> DeleteCourseByIdAsync(int courseId);
    }
}
