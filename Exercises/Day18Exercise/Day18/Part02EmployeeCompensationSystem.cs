using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }

        public int ExperienceInYears { get; set; }

        public decimal bonus;

        public Employee(int id, string name, decimal salary, int years)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = years;
        }
        public virtual decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
        public string DisplayEmployeeDetails()
        {
            return $"Employee Id-{EmployeeId}\nEmployee Name-{EmployeeName}" +
                $"\nAnnual Salary-{CalculateAnnualSalary} ";
        }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {


        }
        public override decimal CalculateAnnualSalary()
        {
            decimal hra = 0.20m * BasicSalary;
            decimal specialAllowance = 0.10m * BasicSalary;
            if (ExperienceInYears >= 5)
            {
                bonus = 50000;
            }
            return base.CalculateAnnualSalary() + hra + specialAllowance + bonus;
        }
    }

    class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {

        }
        public override decimal CalculateAnnualSalary()
        {
            if (ContractDurationInMonths >= 12)
            {
                bonus = 30000;
            }
            return base.CalculateAnnualSalary() + bonus;
        }
    }

    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {

        }
        public override decimal CalculateAnnualSalary()
        {
            return base.CalculateAnnualSalary();
        }
    }

    internal class Part02EmployeeCompensationSystem
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(1, "Sana", 76542, 6);
            PermanentEmployee emp2 = new PermanentEmployee(2, "Megha", 23542, 3);
            Console.WriteLine(emp1.CalculateAnnualSalary());
            Console.WriteLine(emp2.CalculateAnnualSalary());

        }

    }
}
