namespace Day25Exercise
{

    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }

        public double StrikeRate { get; private set; }
        public double Average { get; private set; }

        public void CalculateStats()
        {
            if (BallsFaced == 0)
                throw new DivideByZeroException("Balls faced cannot be zero.");

            StrikeRate = (double)RunsScored / BallsFaced * 100;

            if (!IsOut)
                Average = RunsScored;
            else
                Average = (double)RunsScored / 1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            Console.Write("Enter CSV file path: ");
            string filePath = "../../../" + Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        Player p = new Player
                        {
                            Name = parts[0].Trim(),
                            RunsScored = int.Parse(parts[1]),
                            BallsFaced = int.Parse(parts[2]),
                            IsOut = bool.Parse(parts[3])
                        };

                        p.CalculateStats();

                        if (p.BallsFaced >= 10)
                            players.Add(p);
                    }
                }

                players = players
                            .OrderByDescending(p => p.StrikeRate)
                            .ToList();

                Console.WriteLine();
                Console.WriteLine("Name\t\tRuns\tSR\tAvg");
                Console.WriteLine("-------------------------------------------");

                foreach (var p in players)
                {
                    Console.WriteLine($"{p.Name,-15} {p.RunsScored,-6} {p.StrikeRate,6:F2} {p.Average,8:F2}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found. Please check the path.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid data format in CSV file.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

