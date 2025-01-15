using BaiTap1.DTO.Student;
using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IStudentService
    {
        Task<ApiResponse> GetStudentById(int id);
        Task<ApiResponse> GetAllStudents();
        Task<ApiResponse> CreateStudent(CreateStudentDTO studentDto);
        Task<ApiResponse> UpdateStudent(int id, UpdateStudentDTO studentDto);
        Task<ApiResponse> DeleteStudent(int id);
    }
}
