using System.Threading.Channels;
using System.Xml.Serialization;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int total_classes = 90;
            int attended_classes = 69;
            double percentage = ((double)attended_classes / (double)total_classes) * 100;
            int final_percentage = (int)percentage;
            Console.WriteLine(final_percentage);
            Console.WriteLine();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
            Exercise7();
            Exercise8();
            Exercise9();
            Exercise10();

        }

        /*explanation
        Explain rounding vs truncation impact
        Sol: In truncation, the floating point number is ignored.
        For example, we have 9.76 then the .76 will be ignored in rounding on the other hand,
        in rounding it will look for the nearest whole number. */

        static void Exercise2()
        {


            int marks1 = 55;
            int marks2 = 70;
            int marks3 = 75;
            decimal average = ((decimal)marks1 + (decimal)marks2 + (decimal)marks3) / 3;
            average = Math.Round(average, 2);
            int average_roundoff = (int)average;
            Console.WriteLine(average_roundoff);
            Console.WriteLine();
        }

        /*CONVERSION FLOW:
        STEP1: Firstly, we have to see the data type we have and the target to which we want to convert.
        STEP2: Then, we have two types of conversions:
        1.	Implicit Conversion: It happens automatically by the machine. We does not have to perform any action.
        It does not make any kind of data loss.
        For example: int can be changed to double without any data loss. 
        2.	Explicit Conversion: It does not happen automatically. We do casting.
        There are chances of data loss in this conversion
        For example: if we want to double to an int. It will remove the fractional part of the number which ultimately decreases
        its precision or we can say there will be some data loss.

        PRECISION LOSS SCENARIOS----->
        It generally happens when converting types of different sizes.
        For example:
        We are converting double to float. And we know that double is 64 bit and float is 32 bit. So it will reduce
        the precision by rounding the value or find the approximate value.
        */

        static void Exercise3()
        {
            decimal fine_per_day = 2.3745m;
            int days_overdue = 9;
            decimal total = fine_per_day * days_overdue;
            double total_fine = (double)total;
            System.Console.WriteLine("Total fine is: " + total_fine);
            Console.WriteLine();
        }



        /*Explanation--different types are used and how conversions occur
         * we have used different types of data types bcz days_overdue can't be decimal or float 
         * that is why we have defined int.
         * And fine per day can be in floating point or whole number, so for precision we used decimal
         */
        static void Exercise4()
        {
            decimal account_bal = 2343.5m;
            float interest_rate = 3.4f;
            decimal total_interest = (account_bal * (decimal)interest_rate) / 100;
            decimal total_bal = account_bal + total_interest;
            Console.WriteLine("Total balance after interest: " + total_bal);
            Console.WriteLine();
        }
        /* Safe conversions are the conversions that does not do any data loss.
         * we are making float interest_rate to decimal interest_rate that is safe conversion.
         * Implicit conversions may fail because it can produce precision errors.
         */

        static void Exercise5()
        {

            double cartTotal = 345.54;  //used double for faster performance
            decimal tax = 18m;         //financial calculation needs high precision 
            decimal discount = 5m;
            decimal cartTotalDec = (decimal)cartTotal; //decimal will show the accurate result to the user
            decimal taxVal = (cartTotalDec * tax) / 100;
            decimal total = cartTotalDec + taxVal;
            decimal discountVal = (total * discount) / 100;
            decimal valAfterDis = total - discountVal;
            Console.WriteLine($"Cart Value after discount {valAfterDis}");
            Console.WriteLine();
        }

        static void Exercise6()
        {

            short reading1 = 320;
            short reading2 = 325;
            short reading3 = 321;
            short reading4 = 322;

            double celsius1 = reading1 / 10.0;
            double celsius2 = reading2 / 10.0;
            double celsius3 = reading3 / 10.0;
            double celsius4 = reading4 / 10.0;

            double dailyAvg = (celsius1 + celsius2 + celsius3 + celsius4) / 4.0;
            int tempAvg = Convert.ToInt32(dailyAvg);
            Console.WriteLine($"Average temp in celsius in int is {tempAvg}");
            Console.WriteLine();
        }
        /* overflow and casting concerns
         * short range is -32768 to 32767 if the reading1,reading2,reading3,reading4 exceeds this value overflow occurs
         * we can do casting because it is safe and there will be no data loss if the number is big. There might be possibility
         * that the number is in fraction so it can be stored easily without data loss.
         * */


        static void Exercise7()
        {
            double finalScore = 97.1;
            byte grade = Convert.ToByte(finalScore);
            Console.WriteLine();
        }
        /* validation ensures that the data is within valid range
         * casting choice is how we are converting explicitly from one data type to another.
         * Convert.ToByte caste safely the final score into byte.
         */

        static void Exercise8()
        {

            long Usage = 433843212;
            double MB = (double)Usage / (1024 * 1024);
            double GB = (double)Usage / (1024 * 1024 * 1024);
            int MbRounds = Convert.ToInt32(MB);
            int GbRounds = Convert.ToInt32(GB);
            Console.WriteLine(MbRounds);
            Console.WriteLine(GbRounds);
            Console.WriteLine();
        }
        /* implicit conversion-->it is the conversions that are done automatically or there is no risk of data loss
         * long usage is converted to double
         * rounding methods-->
         * Math.Round(double value)-->rounds to nearest integer
         * Math.Floor(double value)-->rounds down
         * Cast(int value)-->drops the decimal portion
         * 
         */
        static void Exercise9()
        {
            int item = 10;
            ushort maxVal = 15;
            int ValInInt = Convert.ToInt32(maxVal);
            int diff = maxVal - ValInInt;
            Console.WriteLine($"Items to report {item}");
            Console.WriteLine($"Remaining capacity {diff}");
            Console.WriteLine();

            /*
             * Converting a negative signed value to an unsigned type can wrap it to a large positive number, ca
             * using incorrect comparisons or overflow.
             Converting an unsigned value to a larger signed type is safe, as all values are representable.
             */
        }

        static void Exercise10()
        {
            int BasicSalary = 34000;
            double allowance = 1000.32;
            double deductions = 1200.0;
            decimal netSalary = (decimal)BasicSalary + (decimal)allowance - (decimal)deductions;
            Console.WriteLine($"Net salary is {netSalary}");
            Console.WriteLine();
        }
        /*
         * int (basic salary)--->double (allowance and deductions)---->decimal(netSalary)
         * we have moved from int to double because it allows fractional calculations
         * decimal ensures accurate precision.
          */


    }

}













