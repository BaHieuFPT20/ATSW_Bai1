using BaiTap1.DTOs.Course;
using BaiTap1.DTOs;
using BaiTap1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaiTap1.DTOs.Student;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet]
        public Task<ApiResponse> GetAll()
        {

            return _studentService.GetAll();

        }
        [HttpGet("{id}")]
        public Task<ApiResponse> GetById(int id)
        {

            return _studentService.GetById(id);

        }

        [HttpPost("add")]
        public Task<ApiResponse> AddCourse(CreateStudentDTO create)
        {
            return _studentService.CreateStudent(create);
        }
        [HttpPut("update/{id}")]
        public Task<ApiResponse> UpdateCourse(int id, UpdateStudentDTO update)
        {
            return _studentService.UpdateStudent(id, update);
        }
        [HttpDelete("delete/{id}")]
        public Task<ApiResponse> DeleteCourse(int id)
        {
            return _studentService.DeleteStudent(id);
        }
    }
}
