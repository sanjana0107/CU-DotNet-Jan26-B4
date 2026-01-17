namespace Week2Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[5];
            decimal[] annualPremiums = new decimal[5];
            InsurancePremium(names, annualPremiums);

        }
        static void InsurancePremium(string[] names, decimal[] annualPremiums)
        {
            decimal totalPremiumAmount = 0;

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Enter Name:");
                names[i] = Console.ReadLine();
                while (names[i] == "")
                {
                    Console.WriteLine("Enter a valid name: ");
                    names[i] = Console.ReadLine();

                }
                Console.Write("Enter annual premium amount: ");
                annualPremiums[i] = decimal.Parse(Console.ReadLine());
                while (annualPremiums[i] < 0)
                {
                    Console.WriteLine("Enter value greater than zero: ");
                    annualPremiums[i] = decimal.Parse(Console.ReadLine());
                }
                totalPremiumAmount += annualPremiums[i];
            }

            decimal avgPremium = totalPremiumAmount / annualPremiums.Length;
            decimal highestPremium = annualPremiums.Max();
            decimal LowestPremium = annualPremiums.Min();


            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"{"Name",-15}{"Premium",-20}{"Category",-25}");
            Console.WriteLine("--------------------------------------------");
            string category;
            for (int i = 0; i < annualPremiums.Length; i++)
            {

                if (annualPremiums[i] < 10000)
                {
                    category = "LOW";


                }
                else if (annualPremiums[i] <= 10000 && annualPremiums[i] >= 25000)
                {
                    category = "MEDIUM";
                }
                else
                {
                    category = "HIGH";
                }
                Console.WriteLine($"{names[i],-15}{annualPremiums[i],-20}{category,-25}");
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{"Total Premium",-15}: {totalPremiumAmount:F2}");
            Console.WriteLine($"{"Average Premium",-10}: {avgPremium:F2}");
            Console.WriteLine($"{"Highest Premium",-10}: {highestPremium:F2}");
            Console.WriteLine($"{"Lowest Premium",-15}: {LowestPremium:F2}");
        }
    }
}
