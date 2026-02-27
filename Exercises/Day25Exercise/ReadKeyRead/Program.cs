using System.Text;

namespace ReadKeyRead
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter the 4-digit access code: ");

            StringBuilder pin = new StringBuilder();
            ConsoleKeyInfo key;

            while (pin.Length < 4)
            {
                key = Console.ReadKey(true);

                // Accept only digits
                if (char.IsDigit(key.KeyChar))
                {
                    pin.Append(key.KeyChar);
                    Console.Write("*"); // Mask input
                }
                // Handle backspace
                else if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin.Remove(pin.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }

            Console.WriteLine();
            Console.WriteLine("PIN Entered Successfully!");
            Console.WriteLine($"Actual PIN: {pin}");
        }
    }
}


