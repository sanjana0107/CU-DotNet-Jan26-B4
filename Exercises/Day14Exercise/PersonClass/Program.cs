namespace PersonClass
{
    internal enum Departments
    {
        Accounts, IT, Sales
    };
    class Employee
    {

        int id;
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }
        public string Name { get; set; }


        private Departments department;

        public Departments Department
        {
            get { return department; }
            set { department = value; }

        }
        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value > 50000 && value < 90000)
                    salary = value;
            }
        }

        public void Display()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {department}");
            Console.WriteLine($"Salary: {salary}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            e1.SetId(1);
            e1.GetId();
            e1.Name = "Shreya";
            e1.Salary = 55000;
            e1.Department = Departments.IT;
            e1.Display();

        }
    }
}
