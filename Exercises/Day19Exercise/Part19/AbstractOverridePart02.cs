using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part19
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }

        public string ConsumerName { get; set; }

        public decimal UnitsConsumed { get; set; }

        public decimal RatePerUnit { get; set; }

        protected UtilityBill(int id, string name, decimal units, decimal rate)
        {
            this.ConsumerId = id;
            this.ConsumerName = name;
            this.UnitsConsumed = units;
            this.RatePerUnit = rate;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;

        }

        public void PrintBill()
           
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax=CalculateTax(billAmount);
            Console.WriteLine($"Consumer ID- {ConsumerId}");
            Console.WriteLine($"Consumer Name- {ConsumerName}");
            Console.WriteLine($"Total units- {UnitsConsumed}");
            Console.WriteLine($"Rate per unit- {RatePerUnit}");
            Console.WriteLine($"Final Payable Amount- {billAmount + tax}");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {

        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                billAmount += billAmount * 0.1m;
                Console.WriteLine();
            }
            return billAmount;
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {

        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount;

        }
        public new decimal CalculateTax(decimal billAmount)
        {
            return billAmount + billAmount * 0.02m;
        }
    }

    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {

        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit + 150;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }
    }
    internal class AbstractOverridePart02
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>();
            bills.Add(new ElectricityBill(1, "riya", 350, 6));
            bills.Add(new WaterBill(2, "priya", 120, 3));
            bills.Add(new GasBill(3, "siya", 50, 20));
            foreach (var item in bills)
            {
                item.PrintBill();
                Console.WriteLine();
            }
           
        }
    }
}
