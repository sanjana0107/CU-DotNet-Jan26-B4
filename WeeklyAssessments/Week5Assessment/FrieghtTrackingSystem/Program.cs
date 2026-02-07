using System.Collections.Generic;
using System.IO;
using System.Numerics;


namespace FrieghtTrackingSystem
{
    abstract class Shipment
    {
        public string TrackingId { get; set; }

        public double Weight { get; set; }

        public string Destination { get; set; }

        public bool IsFragile { get; set; }

        public bool Isreinforced { get; set; }
        public abstract void ProcessShipment();
    }
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message) { }
    }
    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message) { }
    }
    class ExpressShipment : Shipment
    {
        List<string> restrictedAreas = new List<string> { "North Pole", "South Pole", "Unknown Island" };


        public override void ProcessShipment()
        {
            if (restrictedAreas.Contains(Destination))
                throw new RestrictedDestinationException(" you have entered the restricted destination");

            if (IsFragile && !Isreinforced)
                throw new InsecurePackagingException(" your package is fragile and not reinforced");
        }
    }

    class HeavyFreight : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight cannot be zero");
            }
            if (Weight > 1000)
            {
                Console.WriteLine("Heavy Lift");
            }
        }
    }


    class LogManager : ILoggable
    {
        string path;
        public LogManager()
        {

            string directory = @"..\..\..\";
            string file = "shipment_audit.log";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            path = directory + file;
        }


        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager lm = new LogManager();

            List<Shipment> shipments = new List<Shipment>();
            Shipment s1 = new ExpressShipment()
            {
                TrackingId = "Aok231TYL",
                Weight = 800,
                Destination = "New Delhi",
                IsFragile = true,
                Isreinforced = false
            };
            Shipment s2 = new ExpressShipment()
            {
                TrackingId = "OHT0107UHR",
                Weight = 1230,
                Destination = "Banaras",
                IsFragile = false,
                Isreinforced = false
            };
            Shipment s3 = new ExpressShipment()
            {
                TrackingId = "SJK238",
                Weight = 400,
                Destination = "Chandigarh",
                IsFragile = true,
                Isreinforced = true
            };
            Shipment s4 = new HeavyFreight()
            {
                TrackingId = "SJK238",
                Weight = -20,
                Destination = "Chandigarh",
                IsFragile = true,
                Isreinforced = true

            };
            shipments.Add(s1);
            shipments.Add(s2);
            shipments.Add(s3);
            shipments.Add(s4);
            foreach (var item in shipments)
            {
                try
                {
                    item.ProcessShipment();

                    Console.WriteLine($"Sucess shipment: {item.TrackingId}");
                    lm.SaveLog($" Sucess: {item.TrackingId}");
                }


                catch (RestrictedDestinationException ex)
                {
                    Console.WriteLine($"Security alert, {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Data Entry error, {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {item.TrackingId}");
                }
            }
        }
    }
}
