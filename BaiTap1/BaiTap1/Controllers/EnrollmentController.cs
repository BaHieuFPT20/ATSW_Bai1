using BaiTap1.DTO.Course;
using BaiTap1.DTO.Enrollment;
using BaiTap1.Mapper;
using BaiTap1.Models;
using BaiTap1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollment()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDTO enrollmentDTO)
        {
            var createEnrollment = await _enrollmentService.CreateEnrollmentAsync(enrollmentDTO);
            return CreatedAtAction(nameof(GetByIdEnrollment), new { id = createEnrollment.Id }, createEnrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, UpdateEnrollmentDTO updateEnrollmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var updatedCourse = await _enrollmentService.UpdateEnrollmentByIdAsync(id, updateEnrollmentDTO);
            return Ok(updateEnrollmentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var result = await _enrollmentService.DeleteEnrollmentByIdAsync(id);
            return Ok(result);
        }
    }
}
