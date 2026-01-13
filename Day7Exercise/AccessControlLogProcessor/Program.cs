namespace AccessControlLogProcessor
{
    internal class Program
    {
        static void InvalidAcessLog()
        {
            Console.WriteLine("INVALID ACCESS LOG");

        }
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string[] inputs = input.Split('|');
            if(inputs.Length > 5 )
            {
                InvalidAcessLog();
                return;
            }
            string gateCode=inputs[0];
            if(gateCode.Length>2|| !char.IsLetter(gateCode[0])|| !char.IsDigit(gateCode[1]))
            {
                InvalidAcessLog();
                return;
            }
            char userInitial= char.Parse(inputs[1]);
            if(!char.IsUpper(userInitial))
            {
                InvalidAcessLog();
                return;
            }
            byte accessLevel= byte.Parse(inputs[2]);    
            if(accessLevel<1 || accessLevel>7)
            {
                InvalidAcessLog();
                return;
            }
            if(!bool.TryParse(inputs[3], out bool isActive))
            {
                InvalidAcessLog();
                return; 
            }
            byte attempts= byte.Parse(inputs[4]);
            if(attempts>200)
            {
                InvalidAcessLog();
                return;
            }
            string status;
            if(isActive== false)
            {
                status = "ACCESS DENIED - INACTIVE USER";
            }
            else if(accessLevel >=100)
            {
                status = " ACCESS DENIED - TOO MANY ATTEMPTS";

            }
            else if(accessLevel>=5)
            {
                status = "ACCESS GRANTED - HIGH SECURITY";
            }
            else
            {
                status = "ACCESS GRANTED - STANDARD";
            }
            Console.WriteLine($"{"Gate",-10}: {gateCode}");
            Console.WriteLine($"{"User",-10}: {userInitial}");
            Console.WriteLine($"{"Level",-10}: {accessLevel}");
            Console.WriteLine($"{"Attempts",-10}: {attempts}");
            Console.WriteLine($"{"Status",-10}: {status}");
               

        }


    }
}
