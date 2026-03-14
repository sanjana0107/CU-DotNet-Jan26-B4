namespace Week10Assessment.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }
    }
}
