using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day27Solution
{
    public class Loan
    {
        public string ClientName { get; set; }

        public double Principal { get; set; }

        public double InterestRate { get; set; }

        public double CalculateInterestAmt() => (Principal * InterestRate / 100);

        public string GetRiskLevel()
        {
            if (InterestRate > 10) return "HIGH";
            else if (InterestRate > 5 && InterestRate < 10) return "MEDIUM";
            else return "LOW";

        }
    }
    internal class Part02LoanPortifolioManager
    {
        static void Main(string[] args)
        {
            List<Loan> loans = new List<Loan>();
            Loan l1 = new Loan
            {
                ClientName = "Ramesh",
                Principal = 45000,
                InterestRate = 15
            };
            Loan l2 = new Loan
            {
                ClientName = "Mahesh",
                Principal = 20000,
                InterestRate = 10
            };
            Loan l3 = new Loan
            {
                ClientName = "Suresh",
                Principal = 35000,
                InterestRate = 12
            };

            loans.Add(l1);
            loans.Add(l2);
            loans.Add(l3);
            string directory = @"..\..\..\";
            string file = "LoanData.csv";
            string path = directory + file;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                Console.Write("Enter Client Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Principal Amount: ");
                double principal = double.Parse(Console.ReadLine());

                Console.Write("Enter Interest Rate: ");
                double interest = double.Parse(Console.ReadLine());

                sw.WriteLine($"{name},{principal},{interest}");


            }

            using (StreamReader sr = new StreamReader(path))
            {

                string? line;
                double principal;
                double interest;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];

                    try
                    {
                        if ((!double.TryParse(parts[1], out principal) || (!double.TryParse(parts[2], out interest))))
                        {
                            throw new FormatException("you did not entered the double value.");
                        }

                        Loan loan = new()
                        {
                            ClientName = name,
                            Principal = principal,
                            InterestRate = interest

                        };
                        loans.Add(loan);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR");
                    }


                }
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine($"{"CLIENT",-20}|{"PRINCIPAL",-25}|{"INTEREST",-20}|{"RISKLEVEL",-10}");
                Console.WriteLine("------------------------------------------------------------------------------------");
                foreach (var item in loans)
                {
                    Console.WriteLine($"{item.ClientName,-20}|{item.Principal,-25:C}|{item.CalculateInterestAmt(),-20:C}|{item.GetRiskLevel(),-10}");

                }
            }

        }
    }
}
