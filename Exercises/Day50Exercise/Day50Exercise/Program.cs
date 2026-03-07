namespace Day50Exercise
{
    class Student
    {
        public int StudId { get; set; }

        public string SName { get; set; }

        public Student(int id, string name)
        {
            StudId = id;
            SName = name;
        }
    }

    class ManageData
    {
        public Dictionary<Student, int> studentData = new Dictionary<Student, int>();

        public void AddStudent(Student stud, int marks)
        {
            if (!studentData.ContainsKey(stud))
                studentData.Add(stud, marks);
            else
            {
                if (studentData[stud] < marks)
                    studentData[stud] = marks;
            }
        }
        public void ShowData()
        {
            foreach (var item in studentData)
            {
                Console.WriteLine($"Name - {item.Key.SName} Marks - {item.Value}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(1, "Aman");

            ManageData md = new ManageData();
            md.AddStudent(s1, 56);

            md.AddStudent(new Student(2, "Riya"), 75);

            md.AddStudent(s1, 95);

            md.ShowData();
        }
    }
}
