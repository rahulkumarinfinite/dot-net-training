using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
   
    

        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public DateTime DOB { get; set; }
            public DateTime DOJ { get; set; }
            public string City { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Employee> emp = new List<Employee>
{
     new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1-11-1984"), DOJ = DateTime.Parse("08-06-2011"), City = "Mumbai" },
    new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("2-08-1994"), DOJ = DateTime.Parse("07-07-2012"), City = "Mumbai" },
    new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1-11-1987"), DOJ = DateTime.Parse("12-04-2015"), City = "Pune" },
    new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("03-06-1990"), DOJ = DateTime.Parse("02-02-2016"), City = "Pune" },
    new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("08-03-1991"), DOJ = DateTime.Parse("02-02-2016"), City = "Mumbai" },
    new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("07-11-1989"), DOJ = DateTime.Parse("08-08-2014"), City = "Chennai" },
    new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("02-12-1989"), DOJ = DateTime.Parse("01-06-2015"), City = "Mumbai" },
    new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11-11-1993"), DOJ = DateTime.Parse("06-11-2014"), City = "Chennai" },
    new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12-08-1992"), DOJ = DateTime.Parse("03-12-2014"), City = "Chennai" },
    new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12-04-1991"), DOJ = DateTime.Parse("01-01-2016"), City = "Pune" }
};
                foreach (var i in emp)
                {
                    Console.WriteLine($"EmployeeId = {i.EmployeeID} FirstName = {i.FirstName} LastName = {i.LastName} Title = {i.Title} ,DOB = {i.DOB}, DoJ = {i.DOJ}, City = {i.City}");
                }
                foreach (var i in emp)
                {
                    if (i.City != "Mumbai")
                        Console.WriteLine($"EmployeeId = {i.EmployeeID} FirstName = {i.FirstName} LastName = {i.LastName} Title = {i.Title} ,DOB = {i.DOB}, DoJ = {i.DOJ}, City = {i.City}");
                }
                foreach (var i in emp)
                {
                    if (i.Title == "AsstManager")
                        Console.WriteLine($"EmployeeId = {i.EmployeeID} FirstName = {i.FirstName} LastName = {i.LastName} Title = {i.Title} ,DOB = {i.DOB}, DoJ = {i.DOJ}, City = {i.City}");
                }

                foreach (var i in emp)
                {
                    if (i.LastName.StartsWith("S"))
                        Console.WriteLine($"EmployeeId = {i.EmployeeID} FirstName = {i.FirstName} LastName = {i.LastName} Title = {i.Title} ,DOB = {i.DOB}, DoJ = {i.DOJ}, City = {i.City}");
                }
                Console.Read();



            }
        }
    }

