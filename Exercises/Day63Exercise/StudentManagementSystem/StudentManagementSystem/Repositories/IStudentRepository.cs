using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories
{
    internal interface IStudentRepository
    {
        void AddData(Student student);

        void UpdateData(Student student);

        void DeleteData(int id);

        IEnumerable<Student> GetData();
        Student GetDataById(int id);
    }
}
