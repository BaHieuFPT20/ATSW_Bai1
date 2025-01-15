using BaiTap1.DTO.Course;
using BaiTap1.Mapper;
using BaiTap1.Models;
using BaiTap1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var response = await _courseService.GetCourseById(id);
            if (response.Code != 0)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _courseService.GetAllCourses();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO courseDto)
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

            var response = await _courseService.CreateCourse(courseDto);
            return StatusCode(response.Code == 0 ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDTO courseDto)
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

            var reponse = await _courseService.UpdateCourse(id, courseDto);
            return Ok(reponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = await _courseService.DeleteCourse(id);

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
