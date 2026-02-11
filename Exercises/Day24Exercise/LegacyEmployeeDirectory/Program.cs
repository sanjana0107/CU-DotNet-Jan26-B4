using System.Collections;

namespace LegacyEmployeeDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable= new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");
            if(!employeeTable.ContainsKey(105))
                employeeTable.Add(105, "Edward");
            else
                Console.WriteLine("Key already exists. ");

            string? employeeName = (string?) employeeTable[102];
            Console.WriteLine($"Name of employee 102 is {employeeName}");

            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID: {item.Key}, Name: {item.Value}");
            }         


            employeeTable.Remove(103);
            int count = 0;
            foreach (DictionaryEntry item in employeeTable)
                count++;
            Console.WriteLine($"Total count of remaining employees: {count}");
        }
    }
}
