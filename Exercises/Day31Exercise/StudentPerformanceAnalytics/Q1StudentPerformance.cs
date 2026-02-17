
namespace StudentPerformanceAnalytics
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;

        public override string ToString()
        {
            return $"{Id} {Name} {Class} {Marks}";
        }
    }
    internal class Q1StudentPerformance
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            //top3 students by marks
            var top3Stud = students.OrderByDescending(s => s.Marks).Take(3);
            foreach (var item in top3Stud)
            {
                Console.WriteLine($"Name -{item.Name}, Class - {item.Class}, Marks - {item.Marks}");
            }
            Console.WriteLine("------------------------------------------------");

            //group by class and calculate avg
            var avgByClass = students.GroupBy(s => s.Class).Select(s => new { Class = s.Key, Avg = s.Average(g => g.Marks) });
            foreach (var item in avgByClass)
            {
                Console.WriteLine($"class - {item.Class} Average - {item.Avg}");
            }

            //students who scored below avg
            var studBelowAvg = students.GroupBy(s => s.Class).Select(g => new { Class = g.Key, StudentsBelowAvg = g.Where(s => s.Marks < g.Average(x => x.Marks))});

            Console.WriteLine("------------------------------------------------");

            foreach (var grp in studBelowAvg)
            {
                Console.WriteLine($"Class: {grp.Class}");

                foreach(var student in grp.StudentsBelowAvg)
                Console.WriteLine($"Name - {student.Name} Marks - {student.Marks}");
            }
            Console.WriteLine("------------------------------------------------");
            //order students by class then by marks descending
            var studMarksDesc = students.OrderBy(s => s.Class).ThenByDescending(s => s.Marks).ToList();
            foreach(var stud in studMarksDesc)
            {
                Console.WriteLine($"Class - {stud.Class} Marks - {stud.Marks}");
            }
            Console.WriteLine("------------------------------------------------");

            
        }
    }
}
