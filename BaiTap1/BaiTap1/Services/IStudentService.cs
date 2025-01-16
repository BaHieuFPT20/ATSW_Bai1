using BaiTap1.DTOs.Course;
using BaiTap1.DTOs;
using BaiTap1.DTOs.Student;

namespace BaiTap1.Services
{
    public interface IStudentService
    {
        public Task<ApiResponse> GetAll();

        public Task<ApiResponse> GetById(int id);

        public Task<ApiResponse> CreateStudent(CreateStudentDTO create);

        public Task<ApiResponse> UpdateStudent(int id,UpdateStudentDTO update);

        public Task<ApiResponse> DeleteStudent(int id);
    }
}
