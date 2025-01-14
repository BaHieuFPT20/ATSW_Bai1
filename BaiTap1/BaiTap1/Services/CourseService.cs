using BaiTap1.DATA;
using BaiTap1.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourseByIdAsync(int courseId, Course course)
        {
            var existingCourse = await _db.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
            if (existingCourse != null)
            {
                existingCourse.Title = course.Title;
                existingCourse.Credits = course.Credits;

                _db.Courses.Update(existingCourse);
                await _db.SaveChangesAsync();
            }
            return existingCourse;
        }

        public async Task<bool> DeleteCourseByIdAsync(int courseId)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
