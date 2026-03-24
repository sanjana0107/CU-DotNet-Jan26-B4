using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    internal class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }

        public override string ToString()
        {
            return $"{Name} {Grade}";
        }       
    }
}
