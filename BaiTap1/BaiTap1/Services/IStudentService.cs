using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentByIdAsync(int studentId, Student student);
        Task<bool> DeleteStudentByIdAsync(int studentId);
    }
}
