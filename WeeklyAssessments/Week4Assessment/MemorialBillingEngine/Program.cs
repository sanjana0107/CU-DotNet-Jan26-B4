namespace MemorialBillingEngine
{
    class Patient
    {
        public string Name { get; set; }

        public decimal BaseFee { get; set; }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }


    }

    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }

        public decimal DailyRate { get; set; }

        public override decimal CalculateFinalBill()
        {
            return base.BaseFee + (DaysStayed * DailyRate);

        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public override decimal CalculateFinalBill()
        {
            return base.BaseFee + ProcedureFee;
        }
    }

    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }

        public override decimal CalculateFinalBill()
        {
            if (SeverityLevel >= 1 && SeverityLevel <= 5)
                return base.BaseFee * SeverityLevel;
            return base.BaseFee;
        }
    }

    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public void GenerateDailyReport()
        {
            foreach (var patient in patients)
                Console.WriteLine($"Name-{patient.Name} Final Bill-{patient.CalculateFinalBill()}");
        }

        public decimal CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach (var patient in patients)
                totalRevenue += patient.CalculateFinalBill();
            return totalRevenue;
        }

        public int GetInpatientCount()
        {
            int count = 0;
            foreach (var patient in patients)
                if (patient is Inpatient)
                    count++;
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Patient { Name = "Riya", BaseFee = 700 });
            billing.AddPatient(new Patient { Name = "Siya", BaseFee = 1000 });
            billing.AddPatient(new Inpatient { Name = "Priya", BaseFee = 1000, DaysStayed = 12, DailyRate = 450.78m });
            billing.AddPatient(new Outpatient { Name = "Samridhi", BaseFee = 2300, ProcedureFee = 4500 });
            billing.AddPatient(new EmergencyPatient { Name = "Shruti", BaseFee = 2300, SeverityLevel = 5 });
            billing.AddPatient(new EmergencyPatient { Name = "Rahul", BaseFee = 2300, SeverityLevel = 3 });

            Console.WriteLine("Daily report: ");
            Console.WriteLine("---------------------------------");
            billing.GenerateDailyReport();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Inpatient Count: {billing.GetInpatientCount()}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Total revenue is: {billing.CalculateTotalRevenue()}");
        }

    }

}

