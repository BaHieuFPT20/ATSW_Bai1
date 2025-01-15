using BaiTap1.DTO.Enrollment;
using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IEnrollmentService
    {
        Task<ApiResponse> GetEnrollmentById(int id);
        Task<ApiResponse> GetAllEnrollments();
        Task<ApiResponse> CreateEnrollment(CreateEnrollmentDTO enrollmentDto);
        Task<ApiResponse> UpdateEnrollment(int id, UpdateEnrollmentDTO enrollmentDto);
        Task<ApiResponse> DeleteEnrollment(int id);
    }
}
