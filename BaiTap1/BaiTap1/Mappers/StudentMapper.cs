using BaiTap1.DTOs.Student;
using BaiTap1.Models;

namespace BaiTap1.Mappers
{
    public static class StudentMapper
    {
        public static StudentDTO ToStudentDTO(Student student)
        {
            return new StudentDTO
            {
                ID = student.ID,
                EnrollmentDate = student.EnrollmentDate,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName
            };
        }
        public static Student ToCreateStudentDTO(CreateStudentDTO create)
        {
            return new Student
            {
                EnrollmentDate = create.EnrollmentDate,
                FirstMidName = create.FirstMidName,
                LastName = create.LastName
            };
        }
        public static Student ToStudentFromUpdateStudentDTO(UpdateStudentDTO update)
        {
            return new Student
            {
                EnrollmentDate = update.EnrollmentDate,
                FirstMidName = update.FirstMidName,
                LastName = update.LastName
            };
        }
    }
}
