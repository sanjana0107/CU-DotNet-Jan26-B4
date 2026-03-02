using System.Text;

namespace Day44Exercise
{
    abstract class Subscriber
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();
      
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }

        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate + FixedRate * TaxRate;
        }
    }

    class ConsumerSubscriber : Subscriber, IComparable<Subscriber>
    {
        public decimal DataUsageGB { get; set; }

        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }

        public List<ConsumerSubscriber> consumerSubscribers = new List<ConsumerSubscriber>();

        public override bool Equals(object? obj)
        {
            if (obj is ConsumerSubscriber other)

                return this.Id == other.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(Subscriber? other)
        {
            if (this.JoinDate != other.JoinDate)
                return this.JoinDate.CompareTo(other.JoinDate);
            else
                return this.Name.CompareTo(other.Name);
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name\t\tTotal bill");
            foreach(var subscriber in subscribers)
            {                
                sb.AppendLine($"{subscriber.Name}\t\t{subscriber.CalculateMonthlyBill()}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();
            {
                subscribers["ram@gmail.com"] = new BusinessSubscriber()
                {
                    Id = 1,
                    Name = "Ram",
                    JoinDate = new DateTime(2024, 12, 12),
                    FixedRate = 12,
                    TaxRate = 5
                };


                subscribers["shyam1205@outlook.com"] = new ConsumerSubscriber()
                {
                    Id = 2,
                    Name = "Shyam",
                    JoinDate = new DateTime(2021, 01, 01),
                    DataUsageGB = 12,
                    PricePerGB = 345
                };

                subscribers["priya1212@gmail.com"] = new BusinessSubscriber()
                {
                    Id = 3,
                    Name = "Priya",
                    JoinDate = new DateTime(2022, 12, 12),
                    FixedRate = 22,
                    TaxRate = 8
                };
                subscribers["radhikasingh@gmail.com"] = new ConsumerSubscriber()
                {
                    Id = 3,
                    Name = "Radhika",
                    JoinDate = new DateTime(2022, 12, 23),
                    DataUsageGB = 22,
                    PricePerGB = 250
                };
                subscribers["meghasingla@gmail.com"] = new BusinessSubscriber()
                {
                    Id = 4,
                    Name = "Megha",
                    JoinDate = new DateTime(2023, 12, 1),
                    FixedRate = 34,
                    TaxRate = 5
                };
            };
            var sortedDict = subscribers
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();


            ReportGenerator.PrintRevenueReport(sortedDict);
        
        }
    }
}
