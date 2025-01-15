using BaiTap1.DTO.Enrollment;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class EnrollmentMP
    {
        public static EnrollmentDTO toEnrollmentDTO(this enrollment enrollment)
        {
            return new EnrollmentDTO
            {
                EnrollmentID = enrollment.enrollmentid,
                CourseID = enrollment.courseid,
                StudentID = enrollment.studentid,
                Grade = enrollment.grade,
            };
        }
        public static enrollment toEnrollmentFromCreateEnrollmentDTO(this CreateEnrollmentDTO createEnrollmentDTO)
        {
            return new enrollment
            {
                courseid = createEnrollmentDTO.CourseID,
                studentid = createEnrollmentDTO.StudentID,
                grade = createEnrollmentDTO.Grade,
            };
        }
        public static enrollment toEnrollmentFromUpdateEnrollmentDTO(this UpdateEnrollmentDTO updateEnrollmentDTO)
        {
            return new enrollment
            {
                enrollmentid = updateEnrollmentDTO.EnrollmentID,
                courseid = updateEnrollmentDTO.CourseID,
                studentid = updateEnrollmentDTO.StudentID,
                grade = updateEnrollmentDTO.Grade,
            };
        }
    }
}
