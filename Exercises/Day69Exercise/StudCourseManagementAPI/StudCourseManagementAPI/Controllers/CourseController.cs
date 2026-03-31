using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudCourseManagementAPI.DTOs;
using StudCourseManagementAPI.Models;

namespace StudCourseManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly StudentManagementAPIContext _context;

        public CourseController(StudentManagementAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Course
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Credits
                })
                .ToListAsync();

            return Ok(courses);
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Course
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Credits
                })
                .FirstOrDefaultAsync();

            if (course == null)
                return NotFound();

            return Ok(course);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Credits = dto.Credits
            };

            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseDto dto)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null)
                return NotFound();

            course.Title = dto.Title;
            course.Credits = dto.Credits;

            await _context.SaveChangesAsync();

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null)
                return NotFound();

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

