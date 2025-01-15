using BaiTap1.DTO.Enrollment;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDTO ToEnrollmentDTO(this enrollment enrollmentModel)
        {
            return new EnrollmentDTO
            {
                enrollmentid = enrollmentModel.enrollmentid,
                courseid = enrollmentModel.courseid,
                studentid = enrollmentModel.studentid,
                grade = enrollmentModel.grade
            };
        }

        public static enrollment ToEnrollmentFromDTO(this CreateEnrollmentDTO enrollmentDto)
        {
            return new enrollment
            {
                courseid = enrollmentDto.courseid,
                studentid = enrollmentDto.studentid,
                grade = enrollmentDto.grade
            };
        }

        public static enrollment ToEnrollmentFromDTO(this UpdateEnrollmentDTO enrollmentDto)
        {
            return new enrollment
            {
                courseid = enrollmentDto.courseid,
                studentid = enrollmentDto.studentid,
                grade = enrollmentDto.grade
            };
        }
    }
}
