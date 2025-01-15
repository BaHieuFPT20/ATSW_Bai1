using BaiTap1.DTO.Enrollment;
using BaiTap1.DTO.Student;
using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IStudentService
    {
        Task<ResponAPI> GetAllStudentAsync();
        Task<ResponAPI> GetStudentByIdAsync(int studentId);
        Task<ResponAPI> CreateStudentAsync(CreateStudentDTO createStudentDTO);
        Task<ResponAPI> UpdateStudentByIdAsync(int studentId, UpdateStudentDTO updateStudentDTO);
        Task<ResponAPI> DeleteStudentByIdAsync(int studentId);
    }
}
