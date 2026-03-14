using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Transactions;

namespace Week10Assessment.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public int AccountNumber { get; set; }

        public string Name { get; set; }

        public int Balance { get; set; }
        [ValidateNever]
        public List<Transaction> transactions { get; set; }
    }
}
