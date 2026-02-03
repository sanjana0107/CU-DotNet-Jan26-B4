namespace ExceptionHandling
{


    internal class Program
    {
        static int DivisionException()
        {
            try
            {
                Console.Write("Enter first number: ");
                int x=int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int y = int.Parse(Console.ReadLine());
                return x / y;
            }
            catch
            {
                Console.WriteLine("Divide by zero exception");
            }
            
            return 0;
        }

        static int HandleException(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                Console.WriteLine("informat Exception");
            }
            
            return 0;
        }

        static int IndexException()
        {
            try
            {
                Console.Write("Enter an Array");
                int[] arr = [];
                Console.Write("Enter the index you want to access");
                int index = int.Parse(Console.ReadLine());
                if (index < arr.Length)
                    return arr[index];
            }
            catch(Exception e) {
            {
                Console.WriteLine("IndexOutOfRangeException");
            }
            
            return 0;
        }

        class InvalidStudentAgeException(string message) : Exception(message) { }
        class InvalidStudentNameException(string message) : Exception(message) { }

        static void AgeException()
        {
            while (true) {
                try
                {
                    Console.Write("Emter the age: ");
                    int age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                    {
                        throw new InvalidStudentAgeException("Age should be between 18 and 60");
                    }
                    Console.WriteLine("valid age entered");
                    break;
                }
                catch (InvalidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
        }








        static void Main(string[] args)
        {

        }
    }
}
