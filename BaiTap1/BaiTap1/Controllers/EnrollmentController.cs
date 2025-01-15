using BaiTap1.DTO.Enrollment;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var response = await _enrollmentService.GetEnrollmentById(id);
            if (response.Code != 0)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var response = await _enrollmentService.GetAllEnrollments();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDTO enrollmentDto)
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

            var response = await _enrollmentService.CreateEnrollment(enrollmentDto);
            return StatusCode(response.Code == 0 ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, UpdateEnrollmentDTO enrollmentDto)
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

            var reponse = await _enrollmentService.UpdateEnrollment(id, enrollmentDto);
            return Ok(reponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var response = await _enrollmentService.DeleteEnrollment(id);

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
