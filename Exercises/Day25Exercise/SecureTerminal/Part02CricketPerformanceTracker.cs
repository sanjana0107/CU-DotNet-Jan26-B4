using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Day25Solution
{
    class Player
    {
        public string Name { get; set; }

        public int RunsScored { get; set; }

        public int BallsFaced { get; set; }

        public bool IsOut { get; set; }

        public double Average;

        public double StrikeRate;

        public void CalculateStats()
        {
            StrikeRate = (double)RunsScored / BallsFaced * 100;
            if (IsOut == false) Average = (double)RunsScored;
            else Average = RunsScored / 1.0;
            if (BallsFaced == 0)
                throw new DivideByZeroException("Balls can not be zero. ");
        }
    }

    internal class Part02CricketPerformanceTracker
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            string filename = "players.csv";
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            try
            {
                string? line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    Player p1 = new Player
                    {
                        Name = parts[0].Trim(),
                        RunsScored = int.Parse(parts[1]),
                        BallsFaced = int.Parse(parts[2]),
                        IsOut = bool.Parse(parts[3])
                    };

                    p1.CalculateStats();

                    if (p1.BallsFaced >= 10)
                        players.Add(p1);
                }
                players = players.OrderByDescending(p1 => p1.StrikeRate).ToList();
                Console.WriteLine();
                Console.WriteLine($"Name\t\tRuns\tSR\tAvg");
                foreach (var item in players)
                {
                    Console.WriteLine($"{item.Name}\t{item.RunsScored}\t{item.StrikeRate:F2}\t{item.Average}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not in csv format");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Run or ball value is not a valid integer. ");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Balls cannot be zero.");
            }
        }
    }
         

        
    
}
