namespace ExceptionHandling
{


    internal class Program
    {
        static void CheckDivision()
        {
            try
            {
                Console.Write("Enter first number: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int y = int.Parse(Console.ReadLine());
                int result = x / y;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divide by zero exception");
            }

        }

        static void CheckException()
        {
            try
            {
                Console.Write("Enter a num");
                int s = int.Parse(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.WriteLine("informat Exception");
            }

        }

        static void CheckIndex()
        {
            try
            {
                Console.Write("Enter an Array");
                int[] arr = [];
                Console.Write("Enter the index you want to access");
                int index = int.Parse(Console.ReadLine());
                if (index > arr.Length)
                    throw new IndexOutOfRangeException("index out of range in array");
                Console.WriteLine(arr[index]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }

        }

        class InvalidStudentAgeException(string message) : Exception(message) { }
        class InvalidStudentNameException(string message) : Exception(message) { }

        static void CheckAge()
        {
            while (true)
            {
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
        }
        static void CheckName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the name");
                    string name = Console.ReadLine();
                    for (int i = 0; i < name.Length; i++)
                        if (!Char.IsLetter(name[i]))
                            throw new InvalidStudentNameException("Invalid name Exception");
                    Console.WriteLine("valid name entered");
                    break;
                }
                catch (InvalidStudentNameException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                CheckAge();
                CheckName();
                CheckException();
                CheckDivision();
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("Inner Exception " + e.InnerException);
                Console.WriteLine("StackTrace: " + e.StackTrace);

            }
            finally
            {
                Console.WriteLine("Operations Completed");
            }

        }
    }
}
