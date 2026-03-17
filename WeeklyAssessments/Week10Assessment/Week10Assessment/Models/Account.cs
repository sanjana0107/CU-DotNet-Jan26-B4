using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Week10Assessment.Models
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        public int AccountId { get; set; }

        [Display(Name ="Account Number")]
        public int AccountNumber { get; set; }

        public string Name { get; set; }

        public int Balance { get; set; }
        [ValidateNever]
        public List<Transaction> transactions { get; set; }
    }
}
