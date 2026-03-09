using System.Dynamic;
using System.Threading.Channels;

namespace Day51Exercise
{
    class CreatorStats
    {
        public string CreatorName { get; set; }

        public double[] WeeklyLikes { get; set; }

        public CreatorStats(string name, double[] likes)
        {
            CreatorName = name;
            WeeklyLikes = likes;
        }
    }
    internal class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        public void RegisterCreator(CreatorStats record)
        {
            if (!EngagementBoard.Contains(record))
                EngagementBoard.Add(record);
        }

        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold) =>
             EngagementBoard.Select(x => new
             {
                 name = x.CreatorName,
                 count = x.WeeklyLikes.Count(l => l >= likeThreshold)
             })
            .Where(x => x.count > 0)
            .ToDictionary(x => x.name, x => x.count);
               
            

        public double CalculateAverageLikes() =>
            EngagementBoard.SelectMany(x => x.WeeklyLikes).Average();

        static void Main(string[] args)
        {
            Program prog = new Program();
            while (true)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show top posts");
                Console.WriteLine("3. Overall average weekly likes");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice(1 - 4) : ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter Creator name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter weekly likes(week 1 to 4)");
                    double[] likes = new double[4];
                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = double.Parse(Console.ReadLine());
                    }
                    CreatorStats cs = new CreatorStats(name, likes);
                    prog.RegisterCreator(cs);
                    Console.WriteLine("Creator registered successfully.");                   
                }

                if (choice == 2)
                {
                    Console.WriteLine("Enter like threshold");
                    double threshold = double.Parse(Console.ReadLine());
                    var result =prog.GetTopPostCounts(EngagementBoard, threshold);

                    if(result.Count == 0)
                        Console.WriteLine("no top performing posts this week");
                    else
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                }
                if (choice == 3)
                {
                    double avgLikes = prog.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {avgLikes} ");
                }
                if (choice == 4)
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                    
            }
        }
    }
}
