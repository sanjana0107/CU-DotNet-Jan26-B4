using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudCourseManagementAPI.DTOs;
using StudCourseManagementAPI.Models;

namespace StudCourseManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentManagementAPIContext _context;

        public StudentController(StudentManagementAPIContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Student
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Email,
                    s.Age
                })
                .ToListAsync();

            return Ok(students);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Student
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Email,
                    s.Age
                })
                .FirstOrDefaultAsync();

            if (student == null)
                return NotFound();

            return Ok(student);
        }

   
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Student.Add(student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Email must be unique");
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto dto)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
