using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Week8Assessment
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }

        private int rating;

        public int PerformanceRating
        {
            get { return rating; }
            set
            {
                if (value <= 5 && value >= 1)
                    rating = value;
                else
                    throw new InvalidOperationException("rating cannot be less than zero And greater than 5");
            }
        }

        public int YearsOfExperience { get; set; }

        public decimal DepartmentMultiplier { get; set; }

        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0;
                decimal totalBonus = 0;
                totalBonus += RatingBonus();
                totalBonus += ExperienceBonus();
                totalBonus -= AttendancePenalty(totalBonus);
                totalBonus *= DepartmentMultiplier;
                totalBonus = MaximumCap(totalBonus);
                totalBonus = TaxDeduction(totalBonus);

                return totalBonus;
            }
        }

        public decimal RatingBonus()
        {
            if (PerformanceRating == 5)
                return BaseSalary * 0.25m;
            else if (PerformanceRating == 4)
                return BaseSalary * 0.18m;
            else if (PerformanceRating == 3)
                return BaseSalary * 0.12m;
            else if (PerformanceRating == 2)
                return BaseSalary * 0.05m;
            else if (PerformanceRating == 1)
                return 0.0m;
            else
                throw new InvalidOperationException("Rating entered is out of range");
        }

        public decimal ExperienceBonus()
        {
            if (YearsOfExperience > 10)
                return BaseSalary * 0.05m;
            else if (YearsOfExperience > 5)
                return BaseSalary * 0.03m;
            else
                return 0.0m;
        }

        public decimal AttendancePenalty(decimal currentBonus)
        {
            if (AttendancePercentage < 85)
                return currentBonus * 0.20m;
            else
                return 0.0m;
        }

        public decimal MaximumCap(decimal totalBonus)
        {
            if (totalBonus > BaseSalary * 0.40m)
                return BaseSalary * 0.40m;
            else
                return totalBonus;
        }

        public decimal TaxDeduction(decimal totalBonus)
        {
            decimal total;
            if (totalBonus > 3_00_000)
                total = totalBonus - totalBonus * 0.30m;
            else if (totalBonus > 150000 && totalBonus <= 300000)
                total = totalBonus - totalBonus * 0.20m;
            else
                total = totalBonus - totalBonus * 0.1m;
            return Math.Round(total, 2);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
