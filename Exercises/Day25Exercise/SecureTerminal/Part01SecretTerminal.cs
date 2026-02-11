namespace SecureTerminal
{
    internal class Part01SecretTerminal
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the access code: ");
            int count = 0;
            List<char> pin=new List<char>();    
            ConsoleKeyInfo ch;
            do
            {
                ch = Console.ReadKey(true);
                if (char.IsDigit(ch.KeyChar))
                {
                    Console.Write('*');
                    pin.Add(ch.KeyChar);
                    count++;
                }
                else if(ch.Key== ConsoleKey.Backspace && pin.Count > 0)
                {
                    pin.RemoveAt(pin.Count-1);
                    count--;
                    
                    Console.Write("\b \b");
                }
            }
            while (count < 4);
            Console.WriteLine();
            Console.WriteLine($"Pin is {string.Join("", pin).ToString()}");

        }
    }
}
