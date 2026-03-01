using Day43Exercise;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace Day43Exercise
{
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }
    abstract class FinancialInstrument
    {
        public string InstrumentId { get; set; }

        public string Name { get; set; }

        private string currency;

        public string Currency
        {
            get { return currency; }
            set
            {
                if (value.Length != 3)
                    throw new InvalidDataException("enter a 3-letter code");
                currency = value;
            }
        }


        public DateTime PurchaseDate { get; set; }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new InvalidDataException("Quantity cannot be zero");
                quantity = value;
            }
        }

        private decimal purchasePrice;

        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                if (value < 0)
                    throw new InvalidDataException("Purchase price cannot be zero");
                purchasePrice = value;
            }
        }

        private decimal marketPrice;

        public decimal MarketPrice
        {
            get { return marketPrice; }
            set
            {
                if (value < 0)
                    throw new InvalidDataException("Market price cannot be zero");
                marketPrice = value;
            }
        }


        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"Name - {Name}\n" +
                $"Currency - {Currency}\n" +
                $"purchase date - {PurchaseDate}\n" +
                $"Market Price - {MarketPrice}\n" +
                $"Quantity - {Quantity}\n" +
                $"Total current value - {CalculateCurrentValue():C2}";

        }
    }

    class Equity : FinancialInstrument
    {
        public override decimal CalculateCurrentValue() => MarketPrice * Quantity;


        public string GetRiskCategory()
            => "HIGH";


        public string GenerateReportLine()
            => $"[EQUITY] {GetInstrumentSummary()}";


    }

    class Bond : FinancialInstrument, IReportable, IRiskAssessable
    {
        public override decimal CalculateCurrentValue()
        {
            return MarketPrice * Quantity;
        }

        public string GenerateReportLine()
           => $"[BOND] {GetInstrumentSummary()}";

        public string GetRiskCategory() => "LOW";

    }

    class FixedDeposit : FinancialInstrument, IReportable
    {
        public override decimal CalculateCurrentValue() => MarketPrice * Quantity;

        public string GenerateReportLine()
           => $"[FIXED DEPOSIT] {GetInstrumentSummary()}";

    }

    class MutualFund : FinancialInstrument, IReportable, IRiskAssessable
    {
        public override decimal CalculateCurrentValue()
        {
            return MarketPrice * Quantity;
        }

        public string GetRiskCategory() => "MEDIUM";

        public string GenerateReportLine()
           => $"[MUTUAL FUND] {GetInstrumentSummary()}";

    }
    class Portfolio
    {
        private List<FinancialInstrument> _instruments = new List<FinancialInstrument>();

        private Dictionary<string, FinancialInstrument> _instrumentsKeyPair = new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (_instrumentsKeyPair.ContainsKey($"{instrument.InstrumentId}"))
                throw new Exception("Duplicate Instrument id.");
            _instruments.Add(instrument);
            _instrumentsKeyPair[instrument.InstrumentId] = instrument;
        }

        public void RemoveInstrument(FinancialInstrument instrument)
        {

            if (_instrumentsKeyPair.ContainsKey(instrument.InstrumentId))
            {
                var temp = _instrumentsKeyPair[instrument.InstrumentId];
                _instrumentsKeyPair.Remove(instrument.InstrumentId);
                _instruments.Remove(temp);
            }
        }

        public decimal GetTotalPortfolioValue() => _instruments.Sum(x => x.CalculateCurrentValue());

        public FinancialInstrument? GetInstrumentById(string id) => _instrumentsKeyPair.ContainsKey(id) ? _instrumentsKeyPair[id] : null;

        public IEnumerable<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return _instruments
                .OfType<IRiskAssessable>()
                .Where(r => r.GetRiskCategory().Equals(risk, StringComparison.OrdinalIgnoreCase))
                .Cast<FinancialInstrument>();
        }

        public List<FinancialInstrument> GetAllInstruments() => _instruments;

    }

    public enum TransactionType { BUY, SELL };

    class Transaction
    {

        public int TransactionId { get; set; }

        public int InstrumentId { get; set; }

        public TransactionType Type { get; set; }

        public int Units { get; set; }

        public DateOnly Date { get; set; }

        Transaction[] transactionsArray = [];
        private List<Transaction> _transactionsList = new List<Transaction>();

        private Dictionary<int, int> holdings = new Dictionary<int, int>();

        public void ArrayToList(Transaction[] transactions)
        {
            transactionsArray = transactions;
            this._transactionsList = transactionsArray.ToList();
        }

        public bool TransactionValidation(Transaction transaction)
        {
            if (transaction.Units <= 0)
            {
                Console.WriteLine("Invalid units");
                return false;
            }

            if (transaction.Type == TransactionType.SELL)
            {
                if (!holdings.ContainsKey(transaction.InstrumentId) || holdings[transaction.InstrumentId] < transaction.Units)
                {
                    Console.WriteLine($"Transaction {transaction.TransactionId} : not enough holdings to sell");
                    return false;
                }
            }
            return true;
        }

        public void updateHoldings(Transaction before, Transaction after)
        {
            foreach (var transaction in _transactionsList)
            {
                if (transaction.Type == TransactionType.BUY)
                {
                    if (!holdings.ContainsKey(transaction.InstrumentId))
                        holdings[transaction.InstrumentId] = 0;

                    holdings[transaction.InstrumentId] += transaction.Units;
                }
                else if (transaction.Type == TransactionType.SELL)
                    holdings[transaction.InstrumentId] -= transaction.Units;
            }
        }
    }

    class ReportGenerator
    {
        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("PORTFOLIO SUMMARY\n");
            var groupByType = portfolio.GetAllInstruments().GroupBy(g => g.GetType().Name);

            foreach (var group in groupByType)
            {
                decimal totalInvestment = group.Sum(x => x.Quantity * x.PurchasePrice);

                decimal totalCurrentValue = group.Sum(x => x.Quantity * x.MarketPrice);

                Console.WriteLine($"Instrument type : {group.Key}");
                Console.WriteLine($"Total investment : {totalInvestment}");
                Console.WriteLine($"Total current value : {totalCurrentValue}");
                Console.WriteLine($"Profit/Loss : {(totalCurrentValue - totalInvestment):C2}\n");
            }

            Console.WriteLine($"Overall Portfolio value: {portfolio.GetTotalPortfolioValue():C2}");

            var riskDist = portfolio.GetAllInstruments().OfType<IRiskAssessable>()
                .GroupBy(t => t.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution: ");
            foreach (var risk in riskDist)
                Console.WriteLine($"{risk.Key}: {risk.Count()}");

        }

        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = @"..\..\..\PortfolioReport.txt";
            try
            {
                using StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine("PORTFOLIO REPORT");
                sw.WriteLine($"Report Generated on {DateTime.Now}");
                sw.WriteLine();
                foreach (var item in portfolio.GetAllInstruments())
                    sw.WriteLine($"Total portfolio value: \n{item.GetInstrumentSummary()}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Portfolio portfolio = new();

            Equity equity = new()
            {
                InstrumentId = "EQ001",
                Name = "HAL",
                Currency = "INR",
                PurchaseDate = new DateTime(2024, 12, 12),
                Quantity = 12,
                PurchasePrice = 1200,
                MarketPrice = 4300
            };

            Bond bond = new()
            {
                InstrumentId = "BD002",
                Name = "IFY",
                Currency = "INR",
                PurchaseDate = new DateTime(2025, 1, 12),
                Quantity = 22,
                PurchasePrice = 100,
                MarketPrice = 80
            };

            MutualFund mutual = new()
            {
                InstrumentId = "MF003",
                Name = "HDFC",
                Currency = "INR",
                PurchaseDate = new DateTime(2025, 2, 21),
                Quantity = 34,
                PurchasePrice = 1000,
                MarketPrice = 1300
            };

            portfolio.AddInstrument(mutual);
            portfolio.AddInstrument(equity);
            portfolio.AddInstrument(bond);

            Transaction[] transactions = new Transaction[]
            {
                new()
                {
                    TransactionId = 1,
                    InstrumentId = 1,
                    Type = TransactionType.BUY,
                    Units = 30,
                    Date = new DateOnly(2023, 2, 12)
                },
                new()
                {
                    TransactionId = 2,
                    InstrumentId = 2,
                    Type = TransactionType.SELL,
                    Units = 54,
                    Date = new DateOnly(2025, 1, 1)
                },
                new()
                {
                    TransactionId = 3,
                    InstrumentId = 3,
                    Type = TransactionType.BUY,
                    Units = 78,
                }
            };
            ReportGenerator.GenerateConsoleReport(portfolio);
            ReportGenerator.GenerateFileReport(portfolio);
        }
    }
}

