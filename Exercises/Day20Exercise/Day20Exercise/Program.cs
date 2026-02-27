using System.Globalization;

namespace Day20Exercise
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"{Price} {Duration} {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            return x.Duration.CompareTo(y.Duration);
        }
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber="yec452CW",
                    Price=105000,
                    Duration=new TimeSpan(12,34,8),
                    DepartureTime=new DateTime(2026,01,23,3,03,34)
                },
                new Flight()
                {
                    FlightNumber="efh678HJ",
                    Price=98000,
                    Duration=new TimeSpan(13,4,5),
                    DepartureTime=new DateTime(2026,02,26,1,35,34)
                },
                new Flight()
                {
                    FlightNumber="Abd321XE",
                    Price=167000,
                    Duration=new TimeSpan(9,34,12),
                    DepartureTime=new DateTime(2026,01,15,12,03,34)
                }

            };
            flights.Sort();
            Console.WriteLine("Economy View: ");
            foreach (var item in flights)
            {

                Console.WriteLine(item);
            }
            Console.WriteLine();
            flights.Sort(new DurationComparer());
            Console.WriteLine("Business Runner View: ");
            foreach (var item in flights)
            {

                Console.WriteLine(item);
            }
            Console.WriteLine();
            flights.Sort(new DepartureComparer());
            Console.WriteLine("Early bird View:");
            foreach (var item in flights)
            {

                Console.WriteLine(item);

            }
            Console.WriteLine();
        }
    }
}
