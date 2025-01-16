using BaiTap1.DATA;
using BaiTap1.DTOs;
using BaiTap1.DTOs.Enrollment;
using BaiTap1.Mappers;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BaiTap1.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDBContext _appDbContext;

        public EnrollmentService(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ApiResponse> CreateEnrollment(CreateEnrollmentDTO create)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var enrollment = EnrollmentMapper.ToEnrollmentFromCreateEnrollmentDTO(create);
                var course = _appDbContext.Courses.Find(create.CourseID);
                var student = _appDbContext.Students.Find(create.StudentID);
                enrollment.Student = student;
                enrollment.Course = course;
                // Thêm course mới vào cơ sở dữ liệu
                _appDbContext.Enrollments.Add(enrollment);
                await _appDbContext.SaveChangesAsync();

                response.code = 0;
                response.description = "Enrollment created successfully.";
            }
            catch (Exception ex)
            {
                response.code = 1;
                response.description = $"Error: {ex.Message}";
            }
            return response;
        }

        public async Task<ApiResponse> DeleteEnrollment(int id)
        {
            ApiResponse response = new ApiResponse();
            var enrollment = _appDbContext.Enrollments.Find(id);
            if (enrollment != null)
            {
                try
                {
                    _appDbContext.Remove(enrollment);
                    await _appDbContext.SaveChangesAsync();
                    response.code = 0;
                    response.description = "Delete enrollment successfully.";
                }
                catch (Exception ex)
                {
                    response.code = 1;
                    response.description = $"Error: {ex.Message}";
                }
            }
            else
            {
                response.code = 1;
                response.description = "No enrollment found.";
            }
            return response;
        }

        public async Task<ApiResponse> GetAll()
        {
            ApiResponse response = new ApiResponse();
            var enrollments = await _appDbContext.Enrollments.Include(e => e.Course)  // Bao gồm thông tin Course
                                          .Include(e => e.Student) // Bao gồm thông tin Student
                                          .ToListAsync(); ;
            var enrollmentDTOs = enrollments.Select(enrollment => EnrollmentMapper.ToEnrollmentDTO(enrollment));
            if (enrollments.Count > 0)
            {
                response.description = enrollmentDTOs;
            }
            else
            {
                response.code = 1;
                response.description = "No enrollment found.";
            }
            return response;
        }

        public async Task<ApiResponse> GetById(int id)
        {
            ApiResponse response = new ApiResponse();
            var enrollment = _appDbContext.Enrollments.Find(id);
            if (enrollment != null)
            {
                response.description = EnrollmentMapper.ToEnrollmentDTO(enrollment);
            }
            else
            {
                response.code = 1;
                response.description = "No enrollment found.";
            }
            return response;
        }

        public async Task<ApiResponse> UpdateEnrollment(int id, UpdateEnrollmentDTO update)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var enrollment = _appDbContext.Enrollments.Find(id);
                var course = _appDbContext.Courses.Find(update.CourseID);
                var student = _appDbContext.Students.Find(update.StudentID);
                if (enrollment == null)
                {
                    response.code = 1;
                    response.description = "Enrollment not found.";
                }
                else
                {
                    enrollment.Grade = update.Grade;
                    enrollment.Course = course;
                    enrollment.Student = student;
                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _appDbContext.SaveChangesAsync();

                    response.code = 0;
                    response.description = "Enrollment updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.code = 1;
                response.description = $"Error: {ex.Message}";
            }
            return response;
        }
    }
}
