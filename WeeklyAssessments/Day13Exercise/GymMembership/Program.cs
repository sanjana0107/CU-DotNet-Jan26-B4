namespace GymMembership
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Do you want tread mill(true/false):");
            bool treadMill = bool.Parse(Console.ReadLine());
            Console.Write("Do you want wegihtLifting(true/false): ");
            bool weightLifting=bool.Parse(Console.ReadLine());
            Console.Write("Do you want zumba classes(true/false): ");
            bool zumbaClasses=bool.Parse(Console.ReadLine());
            GymMembership(treadMill, weightLifting, zumbaClasses);
            
        }
        public static void GymMembership(bool treadMill, bool weightLifting, bool ZumbaCLasses)
        {


            double bill = 1000.0;
            if(treadMill|| weightLifting|| ZumbaCLasses)
            {
                if (treadMill) bill += 300;
                if (weightLifting) bill += 500;
                if (ZumbaCLasses) bill+=250;
            }
            else
            {
                bill += 200;
            }
            bill = bill + bill * 0.05;
            Console.WriteLine(bill); 

            


            
        }
    }
}
