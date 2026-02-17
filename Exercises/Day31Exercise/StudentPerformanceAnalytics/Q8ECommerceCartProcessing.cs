using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class CartItem 
    { 
        public string Name; 
        public string Category; 
        public double Price; 
        public int Qty; 
    }
    internal class Q8ECommerceCartProcessing
    {
        static void Main(string[] args)
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };


            //total cart value
            var totalCartValue = cart.Sum(s => s.Price * s.Qty);
            Console.WriteLine($"Total cart value : {totalCartValue}");
            Console.WriteLine(new string('-', 60));



            //group by category and total category cost
            var costByCategory = cart.GroupBy(g => g.Category).Select(s => new { Category = s.Key, TotalCost = s.Sum(x => x.Price * x.Qty) });
            Console.WriteLine("Group by category and total category cost :");
            foreach(var item in costByCategory)
            {
                Console.WriteLine($"Category - {item.Category}, Total category cost - {item.TotalCost}");
            }
            Console.WriteLine(new string('-', 60));


            //apply 10% discount for electronics category
            var electDiscount = cart.Where(c => c.Category == "Electronics").Select(s => new { Category = s.Category, Price = s.Price - (0.1 * s.Price) });
            Console.WriteLine("Price after 10% discount on electronics category :");
            foreach(var item in electDiscount)
            {
                Console.WriteLine($"{item.Price}");
            }

            //return cart summary DTO objects
            var cartSummary = new {TotalItems = cart.Count, TotalCartValue = cart.Sum(x => x.Price * x.Qty),
            TotalQuantity = cart.Sum(x => x.Qty)};
            Console.WriteLine("Cart Summary :");
            Console.WriteLine($"Total cart value : {cartSummary.TotalCartValue}");
            Console.WriteLine($"Total items in the cart : {cartSummary.TotalItems}");
            Console.WriteLine($"Total Quantity : {cartSummary.TotalQuantity}");
            Console.WriteLine(new string('-', 60));
        }
    }
}
