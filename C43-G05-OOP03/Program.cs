using System;
using System.Globalization;

namespace C43_G05_OOP03
{

    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer 
    }

    public class Employee
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private string gender;
        public string Gender
        {
            get { return gender; }
            private set
            {
                if (value == "M" || value == "F")
                    gender = value;
                else
                    throw new ArgumentException("Gender must be 'M' or 'F'.");
            }
        }
        public SecurityLevel SecurityLevel { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime HireDate { get; private set; }

        
        public Employee(int id, string name, string gender, SecurityLevel securityLevel, decimal salary, DateTime hireDate)
        {
            ID = id > 0 ? id : throw new ArgumentException("ID must be a positive number.");
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be empty.");
            Gender = gender; 
            SecurityLevel = securityLevel;
            Salary = salary >= 0 ? salary : throw new ArgumentException("Salary cannot be negative.");
            HireDate = hireDate > DateTime.MinValue ? hireDate : throw new ArgumentException("Invalid hire date.");
        }

        
        public override string ToString()
        {
            return $"Employee ID: {ID}\n" +
                   $"Name: {Name}\n" +
                   $"Gender: {Gender}\n" +
                   $"Security Level: {SecurityLevel}\n" +
                   $"Salary: {DisplaySalaryInCurrency()}\n" +
                   $"Hire Date: {HireDate.ToShortDateString()}";
        }

       
        public string DisplaySalaryInCurrency()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:C}", Salary);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee[] EmpArr = new Employee[3];

                EmpArr[0] = new Employee(
                    id: 1,
                    name: "sayed mohamed sayed ",
                    gender: "M",
                    securityLevel: SecurityLevel.DBA,
                    salary: 120000m,
                    hireDate: new DateTime(2025, 1, 12)
                );

                EmpArr[1] = new Employee(
                    id: 2,
                    name: "mohamed sayed ",
                    gender: "M",
                    securityLevel: SecurityLevel.Guest,
                    salary: 300000m,
                    hireDate: new DateTime(2025, 6, 15)
                );

                EmpArr[2] = new Employee(
                    id: 3,
                    name: "karam mohamed ",
                    gender: "M",
                    securityLevel: SecurityLevel.SecurityOfficer,
                    salary: 150000m,
                    hireDate: new DateTime(2025, 5, 10)
                );

                foreach (Employee emp in EmpArr)
                {
                    Console.WriteLine(emp.ToString());
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
