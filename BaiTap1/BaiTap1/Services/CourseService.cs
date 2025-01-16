using BaiTap1.DATA;
using BaiTap1.DTOs;
using BaiTap1.DTOs.Course;
using BaiTap1.Mappers;
using Microsoft.EntityFrameworkCore;
namespace BaiTap1.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _appDbContext;

        public CourseService(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApiResponse> GetAll()
        {
            ApiResponse response = new ApiResponse();
            var courses = await _appDbContext.Courses.ToListAsync();
            var courseDTOs = courses.Select(course => CourseMapper.ToCourseDTO(course));
            if (courses.Count > 0)
            {
                response.description = courseDTOs;
            }
            else
            {
                response.code = 1;
                response.description = "No courses found.";
            }
            return response;
        }


        public async Task<ApiResponse> GetById(int id)
        {
            ApiResponse response = new ApiResponse();
            var courses = await _appDbContext.Courses.FindAsync(id);
            if (courses != null)
            {
                response.description = CourseMapper.ToCourseDTO(courses);
            }
            else
            {
                response.code = 1;
                response.description = "No courses found.";
            }
            return response;
        }
        public async Task<ApiResponse> CreateCourse(CreateCourseDTO create)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var course = CourseMapper.ToCourseFromCreateCourseDTO(create);
                // Thêm course mới vào cơ sở dữ liệu
                _appDbContext.Courses.Add(course);
                await _appDbContext.SaveChangesAsync();

                response.code = 0;
                response.description = "Course created successfully.";
            }
            catch (Exception ex)
            {
                response.code = 1;
                response.description = $"Error: {ex.Message}";
            }
            return response;
        }

        public async Task<ApiResponse> UpdateCourse(int id, UpdateCourseDTO update)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var course = await _appDbContext.Courses.FindAsync(id);
                if (course == null)
                {
                    response.code = 1;
                    response.description = "Course not found.";
                }
                else
                {
                    // Cập nhật thông tin khóa học
                    course.Title = update.Title;
                    course.Credits = update.Credits;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _appDbContext.SaveChangesAsync();

                    response.code = 0;
                    response.description = "Course updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.code = 1;
                response.description = $"Error: {ex.Message}";
            }
            return response;
        }


        public async Task<ApiResponse> DeleteCourse(int id)
        {
            ApiResponse response = new ApiResponse();
            var course = _appDbContext.Courses.Find(id);
            if (course != null)
            {
                try
                {
                    _appDbContext.Remove(course);
                   await _appDbContext.SaveChangesAsync();
                    response.code = 0;
                    response.description = "Delete course successfully.";
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
                response.description = "No courses found.";
            }
            return response;
        }

    }
}
