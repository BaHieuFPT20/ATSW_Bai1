using BaiTap1.DTOs.Course;
using BaiTap1.DTOs;
using BaiTap1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaiTap1.DTOs.Enrollment;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            this._enrollmentService = enrollmentService;
        }

        [HttpGet]
        public Task<ApiResponse> GetAll()
        {

            return _enrollmentService.GetAll();

        }
        [HttpGet("{id}")]
        public Task<ApiResponse> GetById(int id)
        {

            return _enrollmentService.GetById(id);

        }

        [HttpPost("add")]
        public Task<ApiResponse> AddCourse(CreateEnrollmentDTO create)
        {
            return _enrollmentService.CreateEnrollment(create);
        }
        [HttpPut("update/{id}")]
        public Task<ApiResponse> UpdateCourse(int id, UpdateEnrollmentDTO update)
        {
            return _enrollmentService.UpdateEnrollment(id, update);
        }
        [HttpDelete("delete/{id}")]
        public Task<ApiResponse> DeleteCourse(int id)
        {
            return _enrollmentService.DeleteEnrollment(id);
        }
    }
}
