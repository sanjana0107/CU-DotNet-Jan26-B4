using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    class Loan
    {
        public string LoanNumber { get; set; }

        public string CustomerName { get; set; }

        public decimal Amount { get; set; }

        public int TenureYears { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            Amount = 0;
            TenureYears = 0;
        }

        public Loan(string loanNumber, string customerName, int amount, int tenureYears)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            Amount = amount;
            TenureYears = tenureYears;
        }

        public double CalculateEMI()
        {
            double value = (double)Amount * TenureYears * 0.1;
            return value;

        }
    }

    class HomeLoan(string loanNumber, string customerName, int amount, int tenureYears) : Loan(loanNumber, customerName, amount, tenureYears)
    {
        public new double CalculateEMI()
        {
            double oneTimeValue = (double)Amount * 0.1;
            double interest = (double)Amount * TenureYears * 0.08;
            return oneTimeValue + interest;

        }

    }

    class CarLoan : Loan
    {
        public CarLoan(string loanNumber, string customerName, int amount, int tenureYears) : base(loanNumber, customerName, amount, tenureYears)
        { }
        public new double CalculateEMI()
        {

            double interest = (double)Amount * TenureYears * 0.09;
            return interest + 15000;

        }

    }

    internal class Part01LoanEMISystem
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[4] {
                new Loan("abc", "mkocds", 56098, 4),
                new HomeLoan("sdbc", "cvcds", 1281170, 4),
                new HomeLoan("xzcc", "asdcds", 5600991, 4),
                new CarLoan("ewoid", "asdcds", 560231, 4)
            };
            for (int i = 0; i < loans.Length; i++)
            {
                Console.WriteLine(loans[i].CalculateEMI().ToString("N2"));
            }

        }
    }
}
