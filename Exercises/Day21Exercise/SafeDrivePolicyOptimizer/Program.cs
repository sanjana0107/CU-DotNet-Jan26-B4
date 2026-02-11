using System.Globalization;

/*namespace SafeDrivePolicyOptimizer
{
    class Policys
    {
        public string HolderName { get; set; }

        public decimal Premium { get; set; }

        public int RiskScore { get; set; }

        public DateTime RenewalDate { get; set; }


        Dictionary<string, Policy> PolicyData = new Dictionary<string, Policy>();

        public void BulkAdjustment()
        {
            foreach (var item in PolicyData.Values)
            {
                if (RiskScore > 75)
                {
                    item.Premium = item.Premium + item.Premium * 0.05m;
                }
            }
        }

        public void AddPolicy(string policyId, Policy policy)
        {
            PolicyData[policyId]= policy;
        }
        public override string ToString()
        {
            return $"HolderName- {HolderName}  Premium- {Premium} RiskScore- {RiskScore}" +
                $"Renewal Date- {RenewalDate}";
        }
        public void CleanUp()
        {
            List<string> keysToRemove = new List<string>();
            foreach (var item in PolicyData.Keys)
            {
                TimeSpan difference = DateTime.Now - PolicyData[item].RenewalDate;
                if (difference.TotalDays > 365 * 3)
                {
                    keysToRemove.Add(item);
                }
            }
            foreach (string key in keysToRemove)
            {
                PolicyData.Remove(key);
            }
        }

        public string SecurityCheck(string policyId)
        {
            if(PolicyData.TryGetValue(policyId, out Policy policy))
            {
                return $"Policy Id: {policyId}, Holder: {policy.HolderName} Premium: {policy.Premium}" +
                    $"Risk Score: {policy.RiskScore} Renewal Date: {RenewalDate}";
            }
            return "Not Found";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Policy policyManager = new Policy();
                policyManager.AddPolicy("POL1", new Policy
                {
                    HolderName = "Riya",
                    Premium = 1200.5m,
                    RiskScore = 80,
                    RenewalDate = new DateTime(2021, 6, 1)
                });

                policyManager.AddPolicy("POL2",new Policy
                {                               
                    HolderName = "Siya",
                    Premium = 950.08m,
                    RiskScore = 90,
                    RenewalDate = new DateTime(2024, 12, 12)
                });

                policyManager.AddPolicy("POL3", new Policy
                {
                    HolderName = "Priya",
                    Premium = 1050.08m,
                    RiskScore = 76,
                    RenewalDate = new DateTime(2022, 1, 21)

                });
                policyManager.BulkAdjustment();

                policyManager.CleanUp();

                Console.WriteLine(policyManager.SecurityCheck("POL3"));
                Console.WriteLine(policyManager.SecurityCheck("POL1"));
            }
        }
    }
}
*/