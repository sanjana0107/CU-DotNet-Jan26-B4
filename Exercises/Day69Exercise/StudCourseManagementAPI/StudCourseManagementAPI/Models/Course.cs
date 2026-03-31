namespace StudCourseManagementAPI.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

    }
}
