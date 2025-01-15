using BaiTap1.DATA;
using BaiTap1.DTO.Enrollment;
using BaiTap1.Mapper;
using BaiTap1.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BaiTap1.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDBContext _context;

        public EnrollmentService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> GetEnrollmentById(int id)
        {
            var enrollment = await _context.enrollment.FirstOrDefaultAsync(s => s.enrollmentid == id);
            if (enrollment == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa tuyển sinh",
                    Data = null
                };
            }

            return new ApiResponse
            {
                Code = 0,
                Description = "Thành công",
                Data = enrollment
            };
        }

        public async Task<ApiResponse> GetAllEnrollments()
        {
            var enrollments = await _context.enrollment.ToListAsync();
            return new ApiResponse
            {
                Code = 0,
                Description = "Thành công",
                Data = enrollments
            };
        }

        public async Task<ApiResponse> CreateEnrollment(CreateEnrollmentDTO enrollmentDto)
        {
            var newEnrollment = enrollmentDto.ToEnrollmentFromDTO();

            await _context.enrollment.AddAsync(newEnrollment);
            await _context.SaveChangesAsync();

            return new ApiResponse
            {
                Code = 0,
                Description = "Tạo khóa tuyển sinh thành công",
                Data = newEnrollment.ToEnrollmentDTO()
            };
        }

        public async Task<ApiResponse> UpdateEnrollment(int id, UpdateEnrollmentDTO enrollmentDto)
        {
            var exEnrollment = await _context.enrollment.FirstOrDefaultAsync(s => s.enrollmentid == id);
            if (exEnrollment == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa tuyển sinh để cập nhật",
                    Data = null
                };
            }

            exEnrollment.courseid = enrollmentDto.courseid;
            exEnrollment.studentid = enrollmentDto.studentid;
            exEnrollment.grade = enrollmentDto.grade;

            await _context.SaveChangesAsync();
            return new ApiResponse
            {
                Code = 0,
                Description = "Cập nhật khóa tuyển sinh thành công",
                Data = exEnrollment.ToEnrollmentDTO()
            };
        }

        public async Task<ApiResponse> DeleteEnrollment(int id)
        {
            var enrollment = await _context.enrollment.FirstOrDefaultAsync(s => s.enrollmentid == id);
            if (enrollment == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa tuyển sinh để xóa",
                    Data = null
                };
            }
            try
            {
                _context.enrollment.Remove(enrollment);
                await _context.SaveChangesAsync();
                return new ApiResponse
                {
                    Code = 0,
                    Description = "Xóa khóa tuyển sinh thành công",
                    Data = null
                };
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không thể xóa khóa tuyển sinh vì tồn tại ràng buộc khóa ngoại",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = $"Đã xảy ra lỗi không mong muốn: {ex.Message}",
                };
            }
        }
    }
}
