using BaiTap1.DATA;
using BaiTap1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTap1.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDBContext _db;
        public StudentService(AppDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _db.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _db.Students.FirstOrDefaultAsync(c => c.ID == studentId);
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateStudentByIdAsync(int studentId, Student student)
        {
            var existingStudent = await _db.Students.FirstOrDefaultAsync(c => c.ID == studentId);
            if (existingStudent != null)
            {
                existingStudent.ID = student.ID;
                existingStudent.LastName = student.LastName;
                existingStudent.FirstMidName = student.FirstMidName;
                existingStudent.EnrollmentDate = student.EnrollmentDate;

                _db.Students.Update(existingStudent);
                await _db.SaveChangesAsync();
            }
            return student;
        }
        public async Task<bool> DeleteStudentByIdAsync(int studentId)
        {
            var student = await _db.Students.FirstOrDefaultAsync(c => c.ID == studentId);
            if (student != null) 
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
