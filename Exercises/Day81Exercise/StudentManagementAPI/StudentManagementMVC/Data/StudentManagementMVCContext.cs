using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Data
{
    public class StudentManagementMVCContext : DbContext
    {
        public StudentManagementMVCContext (DbContextOptions<StudentManagementMVCContext> options)
            : base(options)
        {
        }

        public DbSet<StudentManagementMVC.Models.Student> Student { get; set; } = default!;
    }
}
