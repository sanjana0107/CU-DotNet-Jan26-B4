using System.Globalization;

namespace OrderProcessingDomain
{
    class Order
    {
        private DateTime date= DateTime.Now;
        private int orderId;
        private string status;
        public int OrderId
        {
            get { return orderId; }
           }

        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { 
                while(string.IsNullOrEmpty(customerName))
                    Console.WriteLine("enter a valid name");
                   Console.ReadLine() ; }
        }
        private decimal totalAmount;

        public decimal TotalAmount
        {
            get { return totalAmount; }
            
        }
        public decimal AddItem(decimal price)
        {
            totalAmount= totalAmount + price;
            return totalAmount;
        }

        public decimal ApplyDiscount(decimal percentage)
        {
            if (percentage > 1 && percentage < 30)
            {
                totalAmount=totalAmount-(totalAmount * percentage) / 100;
                return totalAmount;

            }
            return totalAmount;
        }
           
        
        public Order(int orderId, string customerName)
        {
            this.orderId = orderId;
            this.customerName = customerName;
            status = "NEW";
        }

        public string GetOrderSummary()
        {
            return $"{"Date",-12}: {date}\n{"Order Id",-12}: {orderId}\n{"Customer",-12}: {customerName}\nTotal Amount: {totalAmount}" +
                $"\n{"Status",-12}: {status}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(101,"Sahil");
            order.AddItem(500);
            order.AddItem(300);
            order.ApplyDiscount(10);
            Console.WriteLine(order.GetOrderSummary());

        }
           

    }
}
