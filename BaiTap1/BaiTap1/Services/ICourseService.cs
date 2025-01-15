using BaiTap1.Models;
using BaiTap1.DTO.Course;

namespace BaiTap1.Services
{
    public interface ICourseService
    {
        Task<ResponAPI> GetAllCourseAsync();
        Task<ResponAPI> GetCourseByIdAsync(int courseId);
        Task<ResponAPI> CreateCourseAsync(CreateCourseDTO courseDTO);
        Task<ResponAPI> UpdateCourseByIdAsync(int courseId, UpdateCourseDTO courseDTO);
        Task<ResponAPI> DeleteCourseByIdAsync(int courseId);
    }
}
