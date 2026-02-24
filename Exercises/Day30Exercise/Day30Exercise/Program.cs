namespace Day30Exercise
{    
    internal class Program
    {
        static List<string> TravelExpense(Dictionary<string, int> expenses)
        {
            Queue<KeyValuePair<string, int>> payers = new Queue<KeyValuePair<string, int>>();
            Queue<KeyValuePair<string, int>> receivers = new Queue<KeyValuePair<string, int>>();

            List<string> settlement = new List<string>();

            var total = expenses.Sum(s => s.Value);

            var share = total / expenses.Count;

            foreach (var person in expenses)
            {
                if (person.Value > share)
                    receivers.Enqueue(new KeyValuePair<string, int>(person.Key, Math.Abs(person.Value - share)));
                else if (person.Value < share)
                    payers.Enqueue(new KeyValuePair<string, int>(person.Key, Math.Abs(person.Value - share)));
            }
            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);
                settlement.Add($"{payer.Key} {receiver.Key} {amount}");

                if (payer.Value > amount)
                    payers.Enqueue(new KeyValuePair<string, int>(payer.Key, payer.Value - amount));

                if (receiver.Value > amount)
                    receivers.Enqueue(new KeyValuePair<string, int>(receiver.Key, receiver.Value - amount));
            }
            return settlement;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> inputData = new Dictionary<string, int>()
            {
                {"Aman",900}, {"Soman", 0}, {"Kartik", 1290}
            };
            List<string> settlement = TravelExpense(inputData);
            foreach (var item in settlement)
            {
                Console.WriteLine(item);
            }
        }
    }
}
