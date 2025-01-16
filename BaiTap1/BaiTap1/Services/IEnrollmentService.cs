using BaiTap1.DTOs;
using BaiTap1.DTOs.Enrollment;

namespace BaiTap1.Services
{
    public interface IEnrollmentService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> GetById(int id);

        public Task<ApiResponse> CreateEnrollment(CreateEnrollmentDTO create);

        public Task<ApiResponse> UpdateEnrollment(int id,UpdateEnrollmentDTO update);

        public Task<ApiResponse> DeleteEnrollment(int id);
    }
}
