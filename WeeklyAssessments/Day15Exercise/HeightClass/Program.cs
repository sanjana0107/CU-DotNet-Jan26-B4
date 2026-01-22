namespace HeightClass
{
    class Height
    {
        public int Feet { get; set; }

        public double Inches { get; set; }



        public string AddHeights(Height h2)
        {
            int feet = this.Feet + h2.Feet;
            double inches = this.Inches + h2.Inches;
            if (inches >= 12)
            {
                feet++;
                inches = inches - 12;
            }
            return $"{feet} feet{inches} inches";

        }

        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;

        }

        public Height(double inches)
        {
            Feet = (int)(inches) / 12;
            Inches = inches%12;

            
        }
        public override string ToString()
        {
            return $"Height- {Feet} feet {Inches} inches";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Height person1 = new Height(5,6.5);
            Height person2 = new Height(5,7.5);
            Height person3 = new Height(155);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            string AddedHeights = person1.AddHeights(person2);
            Console.WriteLine(AddedHeights);
        


        }
    }
}
