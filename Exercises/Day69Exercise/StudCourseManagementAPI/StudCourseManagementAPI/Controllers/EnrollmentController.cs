using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudCourseManagementAPI.DTOs;
using StudCourseManagementAPI.Models;

namespace StudCourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly StudentManagementAPIContext _context;
        public EnrollmentController(StudentManagementAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
       public async Task<IActionResult> GetEnrollments()
        {
            var enrollments = await _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Select(sc => new
                {
                    sc.StudentId,
                    StudentName = sc.Student.Name,
                    sc.CourseId,
                    CourseTitle = sc.Course.Title
                })
                .ToListAsync();

            return Ok(enrollments);
        }



        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollDto enroll)
        {
            var exists = await _context.StudentCourses.AnyAsync(x => x.CourseId == enroll.CourseId && x.StudentId == enroll.StudentId);
            if (exists)
                return BadRequest("already enrolled");

            var enrollment = new StudentCourse
            {
                CourseId = enroll.CourseId,
                StudentId = enroll.StudentId
            };

            _context.StudentCourses.Add(enrollment);
            await _context.SaveChangesAsync();
            return Ok("successfully registered");

        }
    }
}
