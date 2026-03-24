using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private List<Student> _students = new List<Student>();
        private string _file = "../../../student.json";


      
        public void AddData(Student student)
        {
            _students = GetData().ToList();
            var existing = _students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (existing == null)
                _students.Add(student);
            else
                throw new ArgumentException("Student is already existing");

            
            File.WriteAllText(_file, JsonSerializer.Serialize(_students));


        }

        public IEnumerable<Student> GetData()
        {
            if (!File.Exists(_file))
                return new List<Student>();

            string json = File.ReadAllText(_file);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }


        public void DeleteData(int id)
        {

            _students = GetData().ToList();
            var data = _students.FirstOrDefault(x => x.StudentId == id);
            if (data != null)
                _students.Remove(data);

            using (StreamWriter sw = new StreamWriter(_file))
            {
                sw.WriteLine(JsonSerializer.Serialize(_students));
            }
        }

        public void UpdateData(Student student)
        {
            _students = GetData().ToList();
            var data = _students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if(data != null)
            {
                data.Name = student.Name;
                data.Grade = student.Grade;
            }

            using (StreamWriter sw = new StreamWriter(_file))
            {
                sw.WriteLine(JsonSerializer.Serialize(_students));

            }
        }

        public Student? GetDataById(int id)
        {
            _students = GetData().ToList();
            return _students.FirstOrDefault(x => x.StudentId == id);
            
        }

        

        
    }
}
