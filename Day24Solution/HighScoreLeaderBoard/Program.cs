namespace HighScoreLeaderBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double,string> leaderboard = new SortedDictionary<double,string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");
            foreach(var item in leaderboard)
            {
                Console.WriteLine($"Player Name: {item.Value, -12} Lap Time: {item.Key}");
            }

            Console.Write($"Gold medal time is {leaderboard.Keys.First()}");
            double time = 0;
            foreach (var item in leaderboard)
            {
                
                if (item.Value == "SteadyEddie")
                {
                    time = item.Key;
                }
            }
            leaderboard.Remove(time);
            leaderboard.Add(54.00, "SteadyEddie");
            

        }
    }
}
