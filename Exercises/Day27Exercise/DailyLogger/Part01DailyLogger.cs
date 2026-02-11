namespace DailyLogger
{
    internal class Part01DailyLogger
    {
        static void Main(string[] args)
        {

            string directory = @"..\..\..\";
            string file = "journal.txt";
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exists");
            }
            string path = directory + file;            
            using StreamWriter sw = new StreamWriter(path, true);
            
            Console.Write("Daily Reflection ");
            string read = Console.ReadLine();
            sw.WriteLine(read);

          

        }
    }
}
