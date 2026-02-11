using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDrivePolicyOptimizer
{
    class Policy
    {
        public string HolderName { get; set; }

        public decimal Premium { get; set; }

        public int RiskScore { get; set; }

        public DateTime RenewalDate { get; set; }
    }
    class PolicyTracker
    {
        Dictionary<string, Policy> PolicyData = new Dictionary<string, Policy>();

        public void AddPolicy(string policyId, Policy policy)
        {
            PolicyData[policyId] = policy;
        }

        public void BulkAdjustment()
        {
            foreach (var item in PolicyData.Values)
            {
                if (item.RiskScore > 75)
                {
                    item.Premium = item.Premium + item.Premium * 0.05m;
                }
            }
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
            foreach (var key in keysToRemove)
            {
                PolicyData.Remove(key);
            }
        }

        public string SecurityCheck(string policyId)
        {
            if (PolicyData.TryGetValue(policyId, out Policy policy))
            {
                return $"Policy Id: {policyId}, Holder: {policy.HolderName}, Premium: {policy.Premium:C}" +
                    $", Risk Score: {policy.RiskScore}, Renewal Date: {policy.RenewalDate}";
            }
            return "Not Found";
        }

        public void ListAllPolicies()
        {
            foreach (var item in PolicyData)
            {
                Console.WriteLine(SecurityCheck(item.Key));
            }
        }
    }
    internal class Tracker
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            PolicyTracker policyManager = new PolicyTracker();
            policyManager.AddPolicy("POL1", new Policy
            {
                HolderName = "Riya",
                Premium = 1200.5m,
                RiskScore = 80,
                RenewalDate = new DateTime(2021, 6, 1)
            });

            policyManager.AddPolicy("POL2", new Policy
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
            Console.WriteLine("List of all policies: ");
            Console.WriteLine("-------------------------------------------------------------");
            policyManager.ListAllPolicies();
            Console.WriteLine("-------------------------------------------------------------");
            policyManager.BulkAdjustment();

            policyManager.CleanUp();
           
            Console.WriteLine("All active policies: ");
            Console.WriteLine("-------------------------------------------------------------");
            policyManager.ListAllPolicies();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Security check POL2:{policyManager.SecurityCheck("POL2 ")}");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Security check POL3:{policyManager.SecurityCheck("POL3 ")}");
        }
    }
}
