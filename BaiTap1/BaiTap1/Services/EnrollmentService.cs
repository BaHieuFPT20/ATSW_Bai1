using BaiTap1.DATA;
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
        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync()
        {
            return await _db.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return await _db.Enrollments.FirstOrDefaultAsync(c => c.EnrollmentID == enrollmentId);
        }

        public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
        {
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> UpdateEnrollmentByIdAsync(int enrollmentId, Enrollment enrollment)
        {
            var existingEnrollment = await _db.Enrollments.FirstOrDefaultAsync(c => c.EnrollmentID == enrollmentId);
            if (existingEnrollment != null)
            {
                existingEnrollment.CourseID = enrollment.CourseID;
                existingEnrollment.StudentID = enrollment.StudentID;
                existingEnrollment.Grade = enrollment.Grade;

                _db.Enrollments.Update(enrollment);
                await _db.SaveChangesAsync();
            }
            return enrollment;
        }

        public async Task<bool> DeleteEnrollmentByIdAsync(int enrollmentId)
        {
            var enrollment = await _db.Enrollments.FirstOrDefaultAsync(c => c.EnrollmentID == enrollmentId);
            if (enrollment != null)
            {
                _db.Enrollments.Remove(enrollment);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
