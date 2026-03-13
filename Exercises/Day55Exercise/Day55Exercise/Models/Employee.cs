namespace Day55Exercise.Models
{
    public class Employee
    {
        public int EmployyeId { get; set; }

        public string EmployeeName { get; set; }

        public string Position { get; set; }

        public int Salary { get; set; }

        public Employee(int id, string name, string position, int salary)
        {
            EmployyeId = id;
            EmployeeName = name;
            Position = position;
            Salary = salary;
        }
    }
}
