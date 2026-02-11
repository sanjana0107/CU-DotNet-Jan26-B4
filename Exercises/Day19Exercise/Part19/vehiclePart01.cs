namespace Part19
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }

        public Vehicle(string name)
        {
            ModelName = name;

        }
        public abstract void Move();

        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }
    }

    class ElectricCar : Vehicle
    {

        public ElectricCar(string name) : base(name)
        {
            this.ModelName = name;
        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string name) : base(name)
        {
            this.ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high- torque diesel power");
        }
        public new string GetFuelStatus()
        {
            return "Fuel level is stable";
        }


    }

    class CargoPlane: Vehicle
    {
        public CargoPlane(string name): base(name)
        {
            this.ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet");
        }
        public override string GetFuelStatus()
        {
            return $"{base.GetFuelStatus()}, Checking jet fuel reserves...";
        }

    }
    internal class vehiclePart01
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicleNames =
            {
                new ElectricCar("tesla"),
                new HeavyTruck("Ashoka Layland"),
                new CargoPlane("Titanic")

            };
            for(int i = 0; i < vehicleNames.Length; i++)
            {
                vehicleNames[i].Move();
                vehicleNames[i].GetFuelStatus();
            }
        }
    }
}
