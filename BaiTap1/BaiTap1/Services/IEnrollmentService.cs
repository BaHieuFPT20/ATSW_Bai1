using BaiTap1.Models;

namespace BaiTap1.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId);
        Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment);
        Task<Enrollment> UpdateEnrollmentByIdAsync(int enrollmentId, Enrollment enrollment);
        Task<bool> DeleteEnrollmentByIdAsync(int enrollmentId);
    }
}
