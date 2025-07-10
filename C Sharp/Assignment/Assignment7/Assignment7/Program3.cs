using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
//Write a program for following requirement
//a.	To display all employees data
//b.	To display all employees data whose salary is greater than 45000
//c.	To display all employees data who belong to Bangalore Region
//d.	To display all employees data by their names is Ascending order

namespace Assignment7
{

    //


    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Program3
    {
        static void DisplayEmployees(IEnumerable<Employee> employeeList)
        {
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
        static void Main()
        {
            
            List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Amit", EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Neha", EmpCity = "Delhi", EmpSalary = 42000 },
            new Employee { EmpId = 3, EmpName = "Raj", EmpCity = "Bangalore", EmpSalary = 46000 },
            new Employee { EmpId = 4, EmpName = "Simran", EmpCity = "Mumbai", EmpSalary = 39000 },
            new Employee { EmpId = 5, EmpName = "Karan", EmpCity = "Bangalore", EmpSalary = 55000 }
        };

            Console.WriteLine("All Employees:");
            DisplayEmployees(employees);
            Console.WriteLine();

            Console.WriteLine("Employees with Salary > 45000:");
            DisplayEmployees(employees.Where(e => e.EmpSalary > 45000));
            Console.WriteLine();

            Console.WriteLine( "Employees from Bangalore:");
            DisplayEmployees(employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)));
            Console.WriteLine();

            Console.WriteLine("Employees sorted by Name (Ascending):");
            DisplayEmployees(employees.OrderBy(e => e.EmpName));
            Console.Read();
        }

       
    }
}