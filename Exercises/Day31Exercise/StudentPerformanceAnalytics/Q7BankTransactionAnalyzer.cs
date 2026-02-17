using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Transaction 
    { 
        public int Acc; 
        public double Amount; 
        public string Type; 
    }
    internal class Q7BankTransactionAnalyzer
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            //Total balance per account
            var balPerAcc = transactions.GroupBy(a => a.Acc).Select(s => new { Account = s.Key, 
                Balance = s.Sum(x => x.Type == "Credit" ? x.Amount : -x.Amount) });
            Console.WriteLine("Total balance per account :");
            foreach(var tranc in balPerAcc)
            {
                Console.WriteLine($"Account = {tranc.Account}, Balance = {tranc.Balance}");
            }


            //suspicious accs with total debit > credit
            var suspiciousAcc = transactions.GroupBy(g => g.Acc).Select(s => new { Account = s.Key, 
                TotalCredit = s.Where(x => x.Type == "Credit").Sum(x => x.Amount), 
                TotalDebit = s.Where(x => x.Type == "Debit").Sum(x => x.Amount) });
            Console.WriteLine("Suspicious accounts with total debit greater than credit :");
            foreach(var acc in suspiciousAcc)
            {
                Console.WriteLine(acc.Account);
            }
            Console.WriteLine(new string('-', 60));

            //highest transaction amount per acc
            var highestTransaction = transactions.GroupBy(g => g.Acc).Select(s => new {Account = s.Key, Amount = s.Max(x => x.Amount)});
            Console.WriteLine("Highest transaction amount per account :");
            foreach(var acc in highestTransaction)
            {
                Console.WriteLine($"Account - {acc.Account}, Highest transaction - {acc.Amount}");
            }
            Console.WriteLine(new string('-', 60));



        }
    }
}
