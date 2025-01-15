using BaiTap1.DTO.Course;
using BaiTap1.DTO.Student;
using BaiTap1.Mapper;
using BaiTap1.Models;
using BaiTap1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO createStudentDTO)
        {
            var createdStudent = await _studentService.CreateStudentAsync(createStudentDTO);
            return CreatedAtAction(nameof(GetByIdStudent), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDTO updateStudentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var updatedCourse = await _studentService.UpdateStudentByIdAsync(id, updateStudentDTO);
            return Ok(updateStudentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var result = await _studentService.DeleteStudentByIdAsync(id);
            return Ok(result);
        }
    }
}
