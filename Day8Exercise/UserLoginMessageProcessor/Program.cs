namespace UserLoginMessageProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username and Login message");
            string input=Console.ReadLine();
            string[] inputs = input.Split('|', StringSplitOptions.TrimEntries);
            string loginMessage=inputs[1].ToLower();
            string status;
            if (loginMessage.Contains("successful"))
            {
                status="LOGIN SUCCESS(CUSTOM MESSAGE)";            

            }
            else if(loginMessage.Equals("login successful"))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN FAILED";
            }
            Console.WriteLine($"{"User"}{":",5}{inputs[0]}");
            Console.WriteLine($"{"Message"}{":",2}{loginMessage}");
            Console.WriteLine($"{"Status"}{":",3}{status}");



            
        }
    }
}
