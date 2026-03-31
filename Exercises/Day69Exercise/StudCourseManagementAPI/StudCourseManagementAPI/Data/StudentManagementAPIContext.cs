using Microsoft.EntityFrameworkCore;
using StudCourseManagementAPI.Models;

namespace StudCourseManagementAPI
{
    public class StudentManagementAPIContext : DbContext
    {
        public StudentManagementAPIContext(DbContextOptions<StudentManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Student Configuration
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");

                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.Email)
                      .IsRequired();

                entity.HasIndex(s => s.Email)
                      .IsUnique();
            });


            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Title)
                      .IsRequired();

                entity.Property(c => c.Credits)
                      .IsRequired();
            });


            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentCourses");


                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });


                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
