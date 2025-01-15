using BaiTap1.DATA;
using BaiTap1.DTO.Course;
using BaiTap1.Mapper;
using BaiTap1.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BaiTap1.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _context;

        public CourseService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> GetCourseById(int id)
        {
            var course = await _context.course.FirstOrDefaultAsync(s => s.courseid == id);
            if (course == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa học",
                    Data = null
                };
            }

            return new ApiResponse
            {
                Code = 0,
                Description = "Thành công",
                Data = course
            };
        }

        public async Task<ApiResponse> GetAllCourses()
        {
            var courses = await _context.course.ToListAsync();
            return new ApiResponse
            {
                Code = 0,
                Description = "Thành công",
                Data = courses
            };
        }

        public async Task<ApiResponse> CreateCourse(CreateCourseDTO courseDto)
        {
            var newCourse = courseDto.ToCourseFromDTO();

            await _context.course.AddAsync(newCourse);
            await _context.SaveChangesAsync();

            return new ApiResponse
            {
                Code = 0,
                Description = "Tạo khóa học thành công",
                Data = newCourse.ToCourseDTO()
            };
        }

        public async Task<ApiResponse> UpdateCourse(int id, UpdateCourseDTO courseDto)
        {
            var exCourse = await _context.course.FirstOrDefaultAsync(s => s.courseid == id);
            if (exCourse == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa học để cập nhật",
                    Data = null
                };
            }

            exCourse.title = courseDto.title;
            exCourse.credits = courseDto.credits;

            await _context.SaveChangesAsync();
            return new ApiResponse
            {
                Code = 0,
                Description = "Cập nhật khóa học thành công",
                Data = exCourse.ToCourseDTO()
            };
        }

        public async Task<ApiResponse> DeleteCourse(int id)
        {
            var course = await _context.course.FirstOrDefaultAsync(s => s.courseid == id);
            if (course == null)
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không tìm thấy khóa học để xóa",
                    Data = null
                };
            }
            try
            {
                _context.course.Remove(course);
                await _context.SaveChangesAsync();
                return new ApiResponse
                {
                    Code = 0,
                    Description = "Xóa khóa học thành công",
                    Data = null
                };
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return new ApiResponse
                {
                    Code = 1,
                    Description = "Không thể xóa khóa học vì tồn tại ràng buộc khóa ngoại",
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
