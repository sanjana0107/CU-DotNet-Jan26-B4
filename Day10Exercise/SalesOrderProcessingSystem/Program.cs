using System.Xml.Serialization;

namespace SalesOrderProcessingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            string[] categories = new string[7];
            ReadWeekySales(sales);
            decimal total = CalculateTotal(sales);
            decimal avgSales = CalculateAverage(total, sales.Length);
            decimal highest = FindHighestSale(sales, out int highDay);
            decimal lowest = FindLowestSale(sales, out int lowDay);
            decimal discount = CalculateDiscount(total);
            decimal tax = CalculateTax(total-discount);
            decimal finalAmount = CalculateFinalAmount(total, discount, tax);
            GenerateSalesCategory(sales, categories);
            printReport(sales, total, avgSales, highDay, lowDay, highest,
            lowest, discount, tax, finalAmount, categories);
        }

        static void ReadWeekySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                sales[i] = decimal.Parse(Console.ReadLine());
                while (sales[i] < 0)
                {

                    Console.WriteLine("Enter valid input");
                    sales[i] = decimal.Parse(Console.ReadLine());
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                total += sales[i];
            }
            return total;
        }
        static decimal CalculateAverage(decimal total, int days)
        {
            decimal avgSales = total / days;
            return Math.Round(avgSales,2);
        }
        static decimal FindHighestSale(decimal[] sales, out int highDay)
        {
            decimal highestSale = sales[0];
            highDay = 1;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > highestSale)
                {
                    highestSale = sales[i];
                    highDay = i+1;
                }
            }
            return highestSale;

        }

        static decimal FindLowestSale(decimal[] sales, out int lowDay)
        {
            decimal lowestSale = sales[0];
            lowDay = 1;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < lowestSale)
                {
                    lowestSale = sales[i];
                    lowDay = i+1;
                }
            }
            return lowestSale;
        }
        static decimal CalculateDiscount(decimal total)
        {
            decimal discount = 0;

            if (total >= 50000)
            {
                discount = total * 0.1m;
            }
            else
            {
                discount = total * 0.05m;
            }
            return discount;
        }
        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal updatedDiscount = 0;
            decimal discount = CalculateDiscount(total);
            if (isFestivalWeek)
            {
                updatedDiscount = discount + total * 0.05m;
            }
            return updatedDiscount;
        }

        static decimal CalculateTax(decimal amount)
        {

            return amount * 0.18m; ;
        }
        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                {
                    categories[i] = "Low";
                }
                else if (sales[i] >=5000 && sales[i] <= 15000)
                {
                    categories[i] = "Medium";
                }
                else
                {
                    categories[i] = "High";
                }
            }
        }

        static void printReport(decimal[] sales, decimal total, decimal avgSales, int highDay, int lowDay, decimal highestSale,
            decimal lowestSale, decimal discount, decimal tax, decimal finalAmount, string[] category)
        {
            Console.WriteLine("Weekly Sales Summary");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"{"Total Sales",-18}: {total:F2}");
            Console.WriteLine($"Average Daily Sale: {avgSales:F2}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Highest Sale: {highestSale:F2}(Day{highDay})");
            Console.WriteLine($"{"Lowest Sale",-12}: {lowestSale:F2}(Day{lowDay})");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Discount Applied: {discount:F2}");
            Console.WriteLine($"{"Tax Amount",-16}: {tax:F2}");
            Console.WriteLine($"{"Final Payable",-16}: {finalAmount:F2}");
            Console.WriteLine();
            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine($"Day{i + 1} : {category[i]}");
            }
        }
    }
}
