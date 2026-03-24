using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    internal interface IStudentService
    {
        void AddData(Student student);

        void UpdateData(Student student);

        void DeleteData(int id);

        List<Student> GetData();
        Student GetDataById(int id);
    }
}
