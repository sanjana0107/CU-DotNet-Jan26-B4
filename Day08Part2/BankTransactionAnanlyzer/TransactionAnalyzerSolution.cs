using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAnanlyzer
{
    internal class TransactionAnalyzerSolution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter transactionID, Account holder name and transaction narration");
            string input=Console.ReadLine();
            string[] inputs = input.Split('#');
            string transactionID = inputs[0];
            
            string accHolderName=inputs[1].Trim();
            string transactionNarration=inputs[2].Trim().ToLower();
            while(transactionNarration.Contains("  "))
            {
                transactionNarration=transactionNarration.Replace("  "," ");
            }
            string standardNarration = "cash deposit successful";
            string category;
            if(transactionNarration.Contains("deposit")|| transactionNarration.Contains("withdrawal") || transactionNarration.Contains("transfer"))
            {
                category = "CUSTOM TRANSACTION";

            }
            else if(transactionNarration.Contains("deposit") || transactionNarration.Contains("withdrawal") 
                || transactionNarration.Contains("transfer")&& transactionNarration.Equals(standardNarration))
                   {
                category = "STANDARD TRANSACTION";

            }
            else
            {
                category = "NON-FINANCIAL TRANSACTION";
            }
            Console.WriteLine($"Transaction ID : {transactionID}");
            Console.WriteLine($"Account Holder : {accHolderName}");
            Console.WriteLine($"Narration      :{transactionNarration}");
            Console.WriteLine($"Category       : {category}");
        }
    }
}
