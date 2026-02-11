namespace WeeklySalesAnalysisSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            decimal sum = 0;
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                if (sales[i] >= 0)
                {
                    sales[i] = decimal.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Invalid input, Please do re-entry for the same day");
                    break;
                }
                sum = sum + sales[i];
            }
            decimal avgSales = Math.Round(sum / sales.Length,2);
            decimal highestSales = sales.Max();
            decimal lowestSales = sales.Min();
            for(int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > avgSales)
                {
                    count += 1;
                }
            }
            


            string[] salesCategory = new string[sales.Length];
            for (int i = 0; i < salesCategory.Length; i++)
            {
                
                if (sales[i] < 5000)
                {
                    salesCategory[i] = "Low";
                }
                else if (sales[i] >= 5000 && sales[i] <= 15000)
                {
                    salesCategory[i] = "Medium";

                }
                else
                {
                    salesCategory[i] = "High";
                }

                }
                Console.WriteLine($"{ "Total Sales",-18}:{sum}");
                Console.WriteLine($"{"Average Daily Sale",-3}:{avgSales}");
                Console.WriteLine($"{"Highest Sale",-18}:{highestSales}");
                Console.WriteLine($"{"Lowest Sale",-18}:{lowestSales}");
                Console.WriteLine($"{"Days Above Average",-17}:{count}");
                for(int i=0; i < salesCategory.Length; i++)
                {
                    Console.WriteLine($"Day {i} : {salesCategory[i]}");
                }
            }
    }
}

