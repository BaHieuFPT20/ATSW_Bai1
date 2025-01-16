using BaiTap1.DTOs;
using BaiTap1.DTOs.Course;

namespace BaiTap1.Services
{
    public interface ICourseService
    {
        public  Task<ApiResponse> GetAll();

        public Task<ApiResponse> GetById(int id);

        public Task<ApiResponse> CreateCourse(CreateCourseDTO create);

        public Task<ApiResponse> UpdateCourse(int id,UpdateCourseDTO update);

        public Task<ApiResponse> DeleteCourse(int id);

        
    }
}
