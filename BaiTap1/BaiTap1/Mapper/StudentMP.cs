using BaiTap1.DTO.Student;
using BaiTap1.Models;

namespace BaiTap1.Mapper
{
    public static class StudentMP
    {
        public static StudentDTO toStudentDTO(this student student)
        {
            return new StudentDTO
            {
                ID = student.id,
                LastName = student.lastname,
                FirstMidName = student.firstmidname,
                EnrollmentDate = student.enrollmentdate,
            };
        }
        public static student toStudentFromCreateStudentDTO(this CreateStudentDTO createStudentDTO)
        {
            return new student
            {
                lastname = createStudentDTO.LastName,
                firstmidname = createStudentDTO.FirstMidName,
                enrollmentdate = createStudentDTO.EnrollmentDate,
            };
        }
        public static student toStutdentFromUpdateStudentDTO(this UpdateStudentDTO updateStudentDTO)
        {
            return new student
            {
                id = updateStudentDTO.ID,
                lastname = updateStudentDTO.LastName,
                firstmidname = updateStudentDTO.FirstMidName,
                enrollmentdate = updateStudentDTO.EnrollmentDate,
            };
        }
    }
}
