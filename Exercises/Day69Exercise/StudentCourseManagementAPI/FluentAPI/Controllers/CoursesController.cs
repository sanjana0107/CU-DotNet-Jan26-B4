using FluentAPI.DTOs;
using FluentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI.Controllers
{
    [Produces("application/json","application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _context.Courses
            .Include(c => c.StudentCourses)
            .ThenInclude(sc => sc.Student)
            .Select(c => new CourseWithStudentsDto
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                Students = c.StudentCourses.Select(sc => new StudentDto
                {
                    Name = sc.Student.Name,
                    Email = sc.Student.Email,
                    Age = sc.Student.Age
                }).ToList()
            })
            .ToListAsync();

            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Course>>> Create(CourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Credits = dto.Credits
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Created("", course);
        }
    }
}
