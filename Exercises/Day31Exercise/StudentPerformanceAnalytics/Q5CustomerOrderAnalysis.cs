using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

    }

    class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public double Amount { get; set; }

        public DateOnly OrderDate { get; set; }
    }
    internal class Q5CustomerOrderAnalysis
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };


            //get order amount
            var joinedData = customers.Join(orders, o => o.Id, c => c.OrderId, (o, c) => new
            {
                c.CustomerId,
                c.OrderId,
                c.Amount,
                o.Name

            });
            Console.WriteLine("Total order amount per customer: ");
            foreach (var data in joinedData)
            {
                Console.WriteLine($"Name - {data.Name}, Amount - {data.Amount}");
            }
            Console.WriteLine(new string('-', 60));



            //customers with no order
            var noOrderCust = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));
            Console.WriteLine("Customers with no order: ");
            foreach (var cust in noOrderCust)
            {
                Console.WriteLine($"Name = {cust.Name}");
            }
            Console.WriteLine(new string('-', 60));



            //customers spent above 50k
            var custAbove50K = joinedData.GroupBy(g => g.CustomerId).Select(g => new { CustomerId = g.Key, TotalAmount = g.Sum(x => x.Amount) }).Where(c => c.TotalAmount > 50000);
            Console.WriteLine("Customers spent above 50k: ");
            foreach (var cust in custAbove50K)
            {
                Console.WriteLine($"Name = {cust.CustomerId}, Total Amount = {cust.TotalAmount}");
            }
            Console.WriteLine(new string('-', 60));



            //sort customers by total spending
            var sortBySpending = joinedData.GroupBy(c => c.CustomerId).Select(s => new { CustomerId = s.Key, TotalSpending = s.Sum(x => x.Amount) }).OrderByDescending(h => h.TotalSpending);
            Console.WriteLine("Sorting customers by total spending: ");
            foreach(var cust in sortBySpending)
            {
                Console.WriteLine(cust);
            }
            Console.WriteLine(new string('-', 60));
        }
    }
}
