using BaiTap1.DATA;
using BaiTap1.DTOs;
using BaiTap1.DTOs.Course;
using BaiTap1.Models;
using BaiTap1.Services;

using Microsoft.AspNetCore.Mvc;

namespace BaiTap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CourseController : ControllerBase
    {

        //private readonly AppDBContext _dbContext;
        //public CourseController(AppDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Models.Course>>> GetCourses()
        //{
        //    return await _dbContext.Courses.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Models.Course>> GetCourseById(int id)
        //{
        //    var course = await _dbContext.Courses.FindAsync(id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    return course;
        //}

        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpGet]
        public Task<ApiResponse> GetAll()
        {
          
            return  _courseService.GetAll();
                
        }
        [HttpGet("{id}")]
        public Task<ApiResponse> GetById(int id)
        {

            return _courseService.GetById(id);

        }

        [HttpPost("add")]
        public Task<ApiResponse> AddCourse(CreateCourseDTO create)
        {
            return _courseService.CreateCourse(create);
        }
        [HttpPut("update/{id}")]
        public Task<ApiResponse> UpdateCourse(int id,UpdateCourseDTO update)
        {
            return _courseService.UpdateCourse(id,update);
        }
        [HttpDelete("delete/{id}")]
        public Task<ApiResponse> DeleteCourse(int id)
        {
            return _courseService.DeleteCourse(id);
        }
    }
}
