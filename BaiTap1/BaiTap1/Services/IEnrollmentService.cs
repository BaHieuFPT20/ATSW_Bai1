using BaiTap1.DTO.Course;
using BaiTap1.DTO.Enrollment;
using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IEnrollmentService
    {
        Task<ResponAPI> GetAllEnrollmentAsync();
        Task<ResponAPI> GetEnrollmentByIdAsync(int enrollmentId);
        Task<ResponAPI> CreateEnrollmentAsync(CreateEnrollmentDTO createEnrollmentDTO);
        Task<ResponAPI> UpdateEnrollmentByIdAsync(int enrollmentId, UpdateEnrollmentDTO updateEnrollmentDTO);
        Task<ResponAPI> DeleteEnrollmentByIdAsync(int enrollmentId);
    }
}
