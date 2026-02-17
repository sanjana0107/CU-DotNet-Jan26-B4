using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
    }
    class Sale
    {
        public int ProductId;
        public int Qty;
    }

    internal class Q3InventoryAndSalesQuery
    {
        
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            var joinSales = products.Join(sales, p => p.Id, s => s.ProductId, (p, s) => new
            {
                p.Name,
                p.Category,
                p.Price,
                s.Qty,
                TotalAmount = p.Price * s.Qty
            });
            foreach (var item in joinSales)
            {
                Console.WriteLine($"Name - {item.Name}, Category - {item.Category}, Total Revenue - {item.TotalAmount}");
            }
            Console.WriteLine(new string('-', 60));

            //BEST SELLING PRODUCT
            var bestProd = joinSales.MaxBy(s => s.Qty);
            Console.WriteLine($"Name - {bestProd.Name}, Qty - {bestProd.Qty}");
            Console.WriteLine(new string('-', 60));

            //prod with zero sales
            var zeroSalesProd = products.Where(p => !sales.Any(s => p.Id == s.ProductId));
            foreach (var prod in zeroSalesProd)
            {
                Console.WriteLine($"Name - {prod.Name}, Category - {prod.Category}");
            }
            Console.WriteLine(new string('-', 60));
            


        }
    }
}
