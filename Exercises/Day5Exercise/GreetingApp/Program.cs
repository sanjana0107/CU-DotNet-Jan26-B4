using GreetingLibrary;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name=Console.ReadLine();
            Console.WriteLine(GreetingHelper.GetGreeting(name));

        }
    }
}
