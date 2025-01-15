using BaiTap1.DTO.Enrollment;
using BaiTap1.DTO.Student;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class StudentMapper
    {
        public static StudentDTO ToStudentDTO(this student studentModel)
        {
            return new StudentDTO
            {
                id = studentModel.id,
                lastname = studentModel.lastname,
                firstmidname = studentModel.firstmidname,
                enrollmentdate = NormalizeDateTime(studentModel.enrollmentdate)
            };
        }

        public static student ToStudentFromDTO(this CreateStudentDTO studentDto)
        {
            return new student
            {
                lastname = studentDto.lastname,
                firstmidname = studentDto.firstmidname,
                enrollmentdate = NormalizeDateTime(studentDto.enrollmentdate)
            };
        }

        public static student ToStudentFromDTO(this UpdateStudentDTO studentDto)
        {
            return new student
            {
                id = studentDto.id,
                lastname = studentDto.lastname,
                firstmidname = studentDto.firstmidname,
                enrollmentdate = NormalizeDateTime(studentDto.enrollmentdate)
            };
        }

        private static DateTime NormalizeDateTime(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }
            return dateTime.ToUniversalTime();
        }
    }
}
