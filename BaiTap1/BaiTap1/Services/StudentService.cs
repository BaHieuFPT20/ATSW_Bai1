using BaiTap1.DATA;
using BaiTap1.DTO.Student;
using BaiTap1.Mapper;
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
        public async Task<ResponAPI> GetAllStudentAsync()
        {
            var students = await _db.student.ToListAsync();
            return new ResponAPI { Id = 0, Description = "Tìm thấy sinh viên thành công", Data = students };
        }

        public async Task<ResponAPI> GetStudentByIdAsync(int studentId)
        {
            var student = await _db.student.FindAsync(studentId);
            if (student == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy sinh viên", Data = null };
            }

            var studentDTO = new StudentDTO
            {
                ID = student.id,
                LastName = student.lastname,
                FirstMidName = student.firstmidname,
                EnrollmentDate = student.enrollmentdate
            };

            return new ResponAPI { Id = 0, Description = "Tìm thấy sinh viên thành công", Data = studentDTO };
        }

        public async Task<ResponAPI> CreateStudentAsync(CreateStudentDTO createStudentDTO)
        {
            var student = new student
            {
                lastname = createStudentDTO.LastName,
                firstmidname = createStudentDTO.FirstMidName,
                enrollmentdate = createStudentDTO.EnrollmentDate
            };

            _db.student.Add(student);
            await _db.SaveChangesAsync();

            return new ResponAPI
            { Id = 0, Description = "Thêm mới sinh viên thành công", Data = student };
        }

        public async Task<ResponAPI> UpdateStudentByIdAsync(int studentId, UpdateStudentDTO updateStudentDTO)
        {
            var student = await _db.student.FindAsync(studentId);
            if (student == null)
            {
                return new ResponAPI { Id = 1, Description = "Không tìm thấy sinh viên", Data = null };
            }

            student.lastname = updateStudentDTO.LastName;
            student.firstmidname = updateStudentDTO.FirstMidName;
            student.enrollmentdate = updateStudentDTO.EnrollmentDate;

            _db.student.Update(student);
            await _db.SaveChangesAsync();

            return new ResponAPI { Id = 0, Description = "Cập nhật sinh viên thành công", Data = student };
        }

        public async Task<ResponAPI> DeleteStudentByIdAsync(int studentId)
        {
            var student = await _db.student.FindAsync(studentId);
            if (student == null)
            {
                return new ResponAPI { Id = 1, Description = "Lỗi khi xóa sinh viên", Data = null };
            }

            try
            {
                _db.student.Remove(student);
                await _db.SaveChangesAsync();

                return new ResponAPI { Id = 0, Description = "Xóa sinh viên thành công", Data = student };
            }
            catch (DbUpdateException ex)
            {
                // Kiểm tra xem lỗi có liên quan đến khóa ngoại không
                if (ex.InnerException?.Message.Contains("Ràng buộc khóa ngoại không thành công") ?? false)
                {
                    return new ResponAPI { Id = 1, Description = "Không thể xóa sinh viên vì nó có dữ liệu liên quan", Data = null };
                }
                // Xử lý các lỗi khác nếu cần thiết
                return new ResponAPI { Id = 1, Description = "Lỗi khi xóa sinh viên", Data = null };
            }
        }
    }
}
