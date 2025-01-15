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

    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }

        public Book(string title, string author, string isbn)
        {
            Title = !string.IsNullOrWhiteSpace(title) ? title : throw new ArgumentException("Title cannot be empty.");
            Author = !string.IsNullOrWhiteSpace(author) ? author : throw new ArgumentException("Author cannot be empty.");
            ISBN = !string.IsNullOrWhiteSpace(isbn) ? isbn : throw new ArgumentException("ISBN cannot be empty.");
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"ISBN: {ISBN}");
        }
    }

    public class EBook : Book
    {
        public double FileSize { get; private set; } 

        public EBook(string title, string author, string isbn, double fileSize)
            : base(title, author, isbn)
        {
            FileSize = fileSize > 0 ? fileSize : throw new ArgumentException("File size must be positive.");
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"File Size: {FileSize} MB");
        }
    }

    public class PrintedBook : Book
    {
        public int PageCount { get; private set; }

        public PrintedBook(string title, string author, string isbn, int pageCount)
            : base(title, author, isbn)
        {
            PageCount = pageCount > 0 ? pageCount : throw new ArgumentException("Page count must be positive.");
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Page Count: {PageCount}");
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


            try
            {
                EBook ebook = new EBook(
                    title: "CS",
                    author: "sayed mohamed ",
                    isbn: "123-12",
                    fileSize: 2.5
                );

                PrintedBook printedBook = new PrintedBook(
                    title: "Programming Principles",
                    author: "SAYED MOHAMED ",
                    isbn: "123-12",
                    pageCount: 350
                );

                Console.WriteLine("EBook Details:");
                ebook.DisplayDetails();
                Console.WriteLine("---------------------");
                Console.WriteLine("Printed Book Details:");
                printedBook.DisplayDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
