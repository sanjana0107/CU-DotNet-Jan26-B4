using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories
{
    internal class ListStudentRepository : IStudentRepository
    {
        private static List<Student> _StudentList = new List<Student>();
        public void AddData(Student student)
        {
            _StudentList.Add(student);
        }

        public void DeleteData(int id)
        {
            var deletedData = _StudentList.FirstOrDefault(x => x.StudentId == id);
            if (deletedData != null)
            {
                _StudentList.Remove(deletedData);
            }
        }

        public IEnumerable<Student> GetData()
        {
            return _StudentList;
        }

        public Student GetDataById(int id)
        {
            return _StudentList.Find(x => x.StudentId == id);
        }

        public void UpdateData(Student student)
        {
            var existing = _StudentList.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
            }
        }


    }
}
