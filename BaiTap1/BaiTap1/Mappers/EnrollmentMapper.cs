using BaiTap1.DTOs.Enrollment;
using BaiTap1.Models;
namespace BaiTap1.Mappers
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDTO ToEnrollmentDTO(Models.Enrollment enrollment)
        {
            return new EnrollmentDTO
            {
                EnrollmentID = enrollment.EnrollmentID,
                StudentId = enrollment.StudentID,
                Grade = enrollment.Grade,
                CourseID = enrollment.CourseID
            };
        }
       public static Enrollment ToEnrollmentFromCreateEnrollmentDTO(CreateEnrollmentDTO create)
        {
            return new Enrollment
            {
                Grade = create.Grade
            };
        } public static Enrollment ToEnrollmentFromUpdateEnrollmentDTO(UpdateEnrollmentDTO update)
        {
            return new Enrollment
            {
                Grade = update.Grade
            };
        }
        
    }
}
