using BaiTap1.DTO.Student;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _studentService.GetStudentById(id);
            if (response.Code != 0)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _studentService.GetAllStudents();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Code = 1,
                    Description = "Dữ liệu không hợp lệ",
                    Data = null
                });
            }

            var response = await _studentService.CreateStudent(studentDto);
            return StatusCode(response.Code == 0 ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Code = 1,
                    Description = "Dữ liệu không hợp lệ",
                    Data = null
                });
            }

            var reponse = await _studentService.UpdateStudent(id, studentDto);
            return Ok(reponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var response = await _studentService.DeleteStudent(id);

            if (response.Code == 1)
            {
                return StatusCode(409, response);
            }

            return Ok(new
            {
                response.Code,
                response.Description
            });
        }
    }
}
