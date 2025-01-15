using BaiTap1.DATA;
using BaiTap1.DTO.Enrollment;
using BaiTap1.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap1.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDBContext _db;

        public EnrollmentService(AppDBContext db)
        {
            _db = db;
        }
        public async Task<ResponAPI> GetAllEnrollmentAsync()
        {
            var enrollments = await _db.enrollment.ToListAsync();
            return new ResponAPI { Id = 0, Description = "Tìm thấy thành công", Data = enrollments };
        }

        public async Task<ResponAPI> GetEnrollmentByIdAsync(int enrollmentId)
        {
            var enrollment = await _db.enrollment.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return new ResponAPI { Id = 1, Description = "Lỗi không tìm thấy", Data = null };
            }

            var enrollmentDTO = new EnrollmentDTO
            {
                EnrollmentID = enrollment.enrollmentid,
                CourseID = enrollment.courseid,
                StudentID = enrollment.studentid,
                Grade = enrollment.grade,
            };

            return new ResponAPI { Id = 0, Description = "Tìm thấy thành công", Data = enrollmentDTO };
        }

        public async Task<ResponAPI> CreateEnrollmentAsync(CreateEnrollmentDTO enrollmentDTO)
        {
            var enrollment = new enrollment
            {
                courseid = enrollmentDTO.CourseID,
                studentid = enrollmentDTO.StudentID,
                grade = enrollmentDTO.Grade
            };

            _db.enrollment.Add(enrollment);
            await _db.SaveChangesAsync();

            return new ResponAPI
            { Id = 0, Description = "Thêm mới tuyển sinh thành công", Data = enrollment };
        }

        public async Task<ResponAPI> UpdateEnrollmentByIdAsync(int enrollmentId, UpdateEnrollmentDTO enrollmentDTO)
        {
            var enrollment = await _db.enrollment.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy tuyển sinh", Data = null };
            }

            enrollment.courseid = enrollmentDTO.CourseID;
            enrollment.studentid = enrollmentDTO.StudentID;
            enrollment.grade = enrollmentDTO.Grade;

            _db.enrollment.Update(enrollment);
            await _db.SaveChangesAsync();

            return new ResponAPI { Id = 0, Description = "Cập nhật tuyển sinh thành công", Data = enrollment };
        }

        public async Task<ResponAPI> DeleteEnrollmentByIdAsync(int enrollmentId)
        {
            var enrollment = await _db.enrollment.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return new ResponAPI { Id = 1, Description = "Lỗi khi xóa tuyển sinh", Data = null };
            }

            try
            {
                _db.enrollment.Remove(enrollment);
                await _db.SaveChangesAsync();

                return new ResponAPI { Id = 0, Description = "Xóa tuyển sinh thành công", Data = enrollment };
            }
            catch (DbUpdateException ex)
            {
                // Kiểm tra xem lỗi có liên quan đến khóa ngoại không
                if (ex.InnerException?.Message.Contains("Ràng buộc khóa ngoại không thành công") ?? false)
                {
                    return new ResponAPI { Id = 1, Description = "Không thể xóa tuyển sinh vì nó có dữ liệu liên quan", Data = null };
                }
                // Xử lý các lỗi khác nếu cần thiết
                return new ResponAPI { Id = 1, Description = "Lỗi khi xóa tuyển sinh", Data = null };
            }
        }
    }
}
