namespace KitchenAppliance
{
    abstract class Appliance
    {
        public string ModelName { get; set; }

        public int PowConsumption { get; set; }

        protected Appliance(string modelName, int units)
        {
            ModelName = modelName;
            PowConsumption = units;

        }

        public abstract void Cook();

        public virtual void PreHeat()
        {
            Console.WriteLine("Heating");
        }
    }
    interface ITimer
    {
        public void Timer(int mins);
    }

    interface IWifi
    {
        public void NeedsWifi();
    }

    class Microwave : Appliance, ITimer
    {
        public Microwave(string modelName, int units) : base(modelName, units)
        {
        }

        public void Timer(int mins)
        {
            Console.WriteLine($"Set timer to: {mins}");
        }
        public override void Cook()
        {
            Console.WriteLine($"Food is cooking in {ModelName}");
        }
    }

    class Oven : Appliance, ITimer, IWifi
    {
        public Oven(string modelName, int units) : base(modelName, units)
        {
        }

        public void NeedsWifi()
        {
            Console.WriteLine($"{ModelName} is connected to Wifi...");
        }

        public void Timer(int mins)
        {
            Console.WriteLine($"{ModelName} timer set for {mins} mins");
        }

        public override void Cook()
        {
            Console.WriteLine($"Food is cooking in {ModelName}"); 
        }

        public override void PreHeat()
        {
            Console.WriteLine($"{ModelName} is preheating...");
        }
        
    }

    class AirFryer : Appliance
    {
        public AirFryer(string modelName, int units) : base(modelName, units)
        {
        }

        public override void Cook()
        {
            Console.WriteLine("Food is cooking quickly..."); ;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> kitchenAppliance = new List<Appliance>()
            {
                new AirFryer("Samsung", 1200),
                new Microwave("Pigeon", 1500),
                new Oven("LG", 1000)
            };
            foreach(var appliance in kitchenAppliance)
            {
                appliance.Cook();
                if (appliance is ITimer timer)
                    timer.Timer(10);
                if (appliance is IWifi wifi)
                    wifi.NeedsWifi();
                Console.WriteLine();


            }
        }
    }
}
