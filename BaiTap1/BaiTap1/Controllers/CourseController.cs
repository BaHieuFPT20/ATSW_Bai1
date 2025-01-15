using Microsoft.AspNetCore.Http;
using BaiTap1.Models;
using BaiTap1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaiTap1.DTO.Course;

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

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO createCourseDTO)
        {
            var createdCourse = await _courseService.CreateCourseAsync(createCourseDTO);
            return CreatedAtAction(nameof(GetByIdCourse), new { id = createdCourse.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDTO updateCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var updatedCourse = await _courseService.UpdateCourseByIdAsync(id, updateCourseDTO);
            return Ok(updateCourseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponAPI { Id = 1, Description = "Dữ liệu không hợp lệ", Data = null });
            }
            var result = await _courseService.DeleteCourseByIdAsync(id);
            return Ok(result);
        }
    }
}
