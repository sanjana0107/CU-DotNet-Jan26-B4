using StudentManagementSystem.Repositories;
using StudentManagementSystem.Services;
using StudentManagementSystem.Models;
using System.Net.Http.Headers;

namespace StudentManagementSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("choose 1 for list or 2 for json");
            int repoOption = int.Parse(Console.ReadLine());
            IStudentRepository repo = null;
       
            if(repoOption == 1)
            {
                repo = new ListStudentRepository();
            }
            else if(repoOption == 2)
            {
                repo = new JsonStudentRepository();
            }
            else
            {
                Console.WriteLine("invalid option");
                return;
            }
            IStudentService service = new StudentService(repo);
            try
            {
                Console.WriteLine("enter id");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                Console.WriteLine("enter grade");
                int grade = int.Parse(Console.ReadLine());
                Student student = new Student();
                student.StudentId = id;
                student.Name = name;
                student.Grade = grade;
                service.AddData(student);

                IEnumerable<Student> students = service.GetData();
                foreach (var item in students)
                {
                    Console.WriteLine(item);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
