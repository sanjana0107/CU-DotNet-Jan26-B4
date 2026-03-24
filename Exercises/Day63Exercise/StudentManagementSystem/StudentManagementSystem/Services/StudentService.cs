using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    internal class StudentService : IStudentService
    {
        private IStudentRepository _repository { get; set; }

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void AddData(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
                throw new ArgumentException("Enter valid grade between 0-100");

            _repository.AddData(student);

        }

        public void UpdateData(Student student)
        {
            if (!(student.Grade >= 0 && student.Grade <= 100))
            {
                throw new ArgumentException("enter valid grade between 0-100");
            }
            _repository.UpdateData(student);

        }

        public void DeleteData(int id)
        {
            _repository.DeleteData(id);
        }

        public List<Student> GetData()
        {
            return _repository.GetData().ToList();
        }

        public Student GetDataById(int id)
        {            
            var student = _repository.GetDataById(id);
            if (student == null)
                throw new ArgumentException("invalid id");

            return student;
        }
    }
}
