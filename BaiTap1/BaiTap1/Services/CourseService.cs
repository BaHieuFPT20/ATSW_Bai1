using BaiTap1.DATA;
using BaiTap1.DTO.Course;
using BaiTap1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap1.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _db;

        public CourseService(AppDBContext db)
        { 
            _db = db;
        }
        public async Task<ResponAPI> GetAllCourseAsync()
        {
            var courses = await _db.course.ToListAsync();
                return new ResponAPI { Id = 0, Description = "Tìm thấy khóa học thành công", Data = courses };
        }

        public async Task<ResponAPI> GetCourseByIdAsync(int courseId)
        {
            var course = await _db.course.FindAsync(courseId);
            if (course == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy khóa học", Data = null };
            }

            var courseDTO = new CourseDTO
            {
                CourseID = course.courseid,
                Title = course.title,
                Credits = course.credits
            };

            return new ResponAPI { Id = 0, Description = "Tìm thấy khoá học thành công", Data = courseDTO };
        }

        public async Task<ResponAPI> CreateCourseAsync(CreateCourseDTO courseDTO)
        {
            var course = new course
            {
                title = courseDTO.Title,
                credits = courseDTO.Credits
            };

            _db.course.Add(course);
            await _db.SaveChangesAsync();

            return new ResponAPI 
            { Id = 0, Description = "Thêm mới khóa học thành công", Data = course };
        }

        public async Task<ResponAPI> UpdateCourseByIdAsync(int courseId, UpdateCourseDTO courseDTO)
        {
            var course = await _db.course.FindAsync(courseId);
            if (course == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy khóa học", Data = null };
            }

            course.title = courseDTO.Title;
            course.credits = courseDTO.Credits;

            _db.course.Update(course);
            await _db.SaveChangesAsync();

            return new ResponAPI { Id = 0, Description = "Cập nhật khóa học thành công", Data = course };
        }

        public async Task<ResponAPI> DeleteCourseByIdAsync(int courseId)
        {
            var course = await _db.course.FindAsync(courseId);
            if (course == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy khóa học", Data = null };
            }

            try
            {
                _db.course.Remove(course);
                await _db.SaveChangesAsync();

                return new ResponAPI { Id = 0, Description = "Xóa khóa học thành công", Data = course };
            }
            catch (DbUpdateException ex)
            {
                // Kiểm tra xem lỗi có liên quan đến khóa ngoại không
                if (ex.InnerException?.Message.Contains("Ràng buộc khóa ngoại không thành công") ?? false)
                {
                    return new ResponAPI { Id = 1, Description = "Không thể xóa khóa học vì nó có dữ liệu liên quan", Data = null };
                }
                // Xử lý các lỗi khác nếu cần thiết
                return new ResponAPI { Id = 1, Description = "Lỗi khi xóa khóa học", Data = null };
            }
        }
    }
}
