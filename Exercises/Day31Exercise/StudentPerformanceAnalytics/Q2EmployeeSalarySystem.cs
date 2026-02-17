using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }

    internal class Q2EmployeeSalarySystem
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {

                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            //get highest and lowest salary in each department
            var lowByDept = employees.GroupBy(s => s.Dept).Select(s => new {Dept = s.Key, MinSalary = s.Min(a => a.Salary), MaxSalary = s.Max(b => b.Salary) });

            foreach (var emp in lowByDept)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine(new string('-',60));

            //count employees per dept
            var countByDept = employees.GroupBy(s => s.Dept).Select(s => new { Deparment = s.Key, CountByDept = s.Count() });
            foreach(var emp in countByDept)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine(new string('-', 60));

            //filter employees joined after 2020
            var empAfter2020 = employees.Where(s => s.JoinDate.Year > 2020);
            foreach(var emp in empAfter2020)
            {
                Console.WriteLine($"Name - {emp.Name}, Department - {emp.Dept}, Joining Year - {emp.JoinDate.Year}");
            }
            Console.WriteLine(new string('-', 60));


            //project anonymous objects with Name and Annual Salary
            var anonyObj = employees.Select(s => new { Name = s.Name, AnnualSalary = (s.Salary * 12) });
            foreach(var emp in anonyObj)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine(new string('-', 60));
            



        }
    }
}
