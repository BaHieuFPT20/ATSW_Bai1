using BaiTap1.DTO.Course;
using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface ICourseService
    {
        Task<ApiResponse> GetCourseById(int id);
        Task<ApiResponse> GetAllCourses();
        Task<ApiResponse> CreateCourse(CreateCourseDTO courseDto);
        Task<ApiResponse> UpdateCourse(int id, UpdateCourseDTO courseDto);
        Task<ApiResponse> DeleteCourse(int id);
    }
}
