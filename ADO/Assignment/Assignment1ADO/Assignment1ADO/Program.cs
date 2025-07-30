using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1ADO
{
    /*
     * 1. Create a console application and add class named Employee with following field.
Employee Class
EmployeeID (Integer)
FirstName (String)
LastName (String)
Title (String)
DOB (Date)
DOJ (Date)
City (String)
    */

    public class Employees {
       public int EmployeeID { get; set; }
        public string FirstName { get; set; }
       public  String LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
       public DateTime DOJ { get; set; }
      public   string City { get; set; }
        public static List<Employees> GetEmployees()
        {
            
               List<Employees> Emplist = new List<Employees>()
            {
             new Employees{EmployeeID=1001,FirstName="Malcolm",LastName="Daruwalla",Title="Manager",DOB=Convert.ToDateTime("11-16-1984"),DOJ=Convert.ToDateTime("6/8/2011"),City="Mumbai"},
              new Employees{EmployeeID=1002,FirstName="Asdin",LastName="Dhalla",Title="AsstManager",DOB=Convert.ToDateTime("08-20-1984"),DOJ=Convert.ToDateTime("7/7/2011"),City="Mumbai"},
              new Employees{EmployeeID=1003,FirstName="Madhavi",LastName="Oza",Title="Consultant",DOB=Convert.ToDateTime("11-14-1987"),DOJ=Convert.ToDateTime("4/12/2015"),City="Pune"},
              new Employees{EmployeeID=1004,FirstName="Saba",LastName="Shaikh",Title="SE",DOB=Convert.ToDateTime("06-3-1990"),DOJ=Convert.ToDateTime("2/2/2016"),City="Pune"},
              new Employees{EmployeeID=1005,FirstName="Nazia",LastName="Shaikh",Title="SE",DOB=Convert.ToDateTime("03-8-1991"),DOJ=Convert.ToDateTime("2/2/2016"),City="Mumbai"},
              new Employees{EmployeeID=1006,FirstName="Amit",LastName="Pathak",Title="Consultant",DOB=Convert.ToDateTime("11-7-1989"),DOJ=Convert.ToDateTime("8/8/2014"),City="Channai"},
              new Employees{EmployeeID=1007,FirstName="Vijay",LastName="Natarajan",Title="Consultant",DOB=Convert.ToDateTime("12-2-1989"),DOJ=Convert.ToDateTime("6/1/2015"),City="Mumbai"},
              new Employees{EmployeeID=1008,FirstName="Rahul",LastName="Dubey",Title="Associate",DOB=Convert.ToDateTime("11-11-1993"),DOJ=Convert.ToDateTime("11/6/2014"),City="Channai"},
              new Employees{EmployeeID=1009,FirstName="Suresh",LastName="Mistry",Title="Associate",DOB=Convert.ToDateTime("08-12-1992"),DOJ=Convert.ToDateTime("12/3/2014"),City="Channai"},
              new Employees{EmployeeID=1010,FirstName="Sumit",LastName="Shah",Title="Manager",DOB=Convert.ToDateTime("04-12-1991"),DOJ=Convert.ToDateTime("1/2/2016"),City="Pune"},

            };
                
            
            return Emplist;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            var emp = Employees.GetEmployees();

            /*Question 2
             * 1. Display a list of all the employee who have joined before 1/1/2015
              2. Display a list of all the employee whose date of birth is after 1/1/1990
               3. Display a list of all the employee whose designation is Consultant and Associate
              4. Display total number of employees
              5. Display total number of employees belonging to “Chennai”
              6. Display highest employee id from the list
             7. Display total number of employee who have joined after 1/1/2015
             8. Display total number of employee whose designation is not “Associate”
              9. Display total number of employee based on City
               10. Display total number of employee based on city and title
              11. Display total number of employee who is youngest in the list
            */
            var q1 = emp.Where(e => e.DOJ <  DateTime.Parse("1/1/2015")).ToList();
            foreach(var i in q1)
            {
                Console.WriteLine(i.EmployeeID+" "+i.FirstName+" "+i.LastName+" "+i.Title+" "+i.Title+" "+i.DOB+" "+i.DOJ+" "+i.City);
            }

            Console.WriteLine("------------------------------------------------Query2----------------------------------------------------");
            var q2 = emp.Where(e => e.DOB > DateTime.Parse("1/1/1990")).ToList();
            foreach (var i in q2)
            {
                Console.WriteLine(i.EmployeeID + " " + i.FirstName + " " + i.LastName + " " + i.Title + " " + i.Title + " " + i.DOB + " " + i.DOJ + " " + i.City);
            }
            Console.WriteLine("------------------------------------------------Query3----------------------------------------------------");
            var q3 = emp.Where(e => e.Title =="Consultant" || e.Title=="Associate").ToList();
            foreach (var i in q3)
            {
                Console.WriteLine(i.EmployeeID + " " + i.FirstName + " " + i.LastName + " " + i.Title + " " + i.Title + " " + i.DOB + " " + i.DOJ + " " + i.City);
            }
            Console.WriteLine("------------------------------------------------Query4----------------------------------------------------");
            var q4 = emp.Count();
            Console.WriteLine("Number of emmployee is " + q4);

            Console.WriteLine("------------------------------------------------Query5----------------------------------------------------");
            var q5 = emp.Count(e => e.City == "Channai");
            Console.WriteLine("Number of emmployee in Channai are " + q5);
            Console.WriteLine("------------------------------------------------Query6----------------------------------------------------");
            var q6 = emp.Max(e=>e.EmployeeID);
            Console.WriteLine("Heighest number of employee in the list is " + q6);
            Console.WriteLine("------------------------------------------------Query7----------------------------------------------------");
            var q7 = emp.Count(e=>e.DOJ>DateTime.Parse("1/1/2015"));
            Console.WriteLine("Number of employee which join after the 1/1/2015 " + q6);
            Console.WriteLine("------------------------------------------------Query8----------------------------------------------------");
            var q8 = emp.Count(e => e.Title !="Associates");
            Console.WriteLine("Number of employee which are not associates " + q8);
            Console.WriteLine("------------------------------------------------Query9----------------------------------------------------");
            var q9 = emp.GroupBy(e=>e.City).Select(e=>new { City=e.Key,count= e.Count()});
            foreach (var i in q9)
            {
                Console.WriteLine(i.count+" "+i.City);
      
            }
            Console.WriteLine("------------------------------------------------Query10----------------------------------------------------");
            var q10 = emp.GroupBy(e =>new { e.City , e.Title}).Select(e => new { City = e.Key.City,Title=e.Key.Title, count = e.Count() });
            foreach (var i in q10)
            {
                Console.WriteLine(i.count + " " + i.City+" "+i.Title);

            }
            Console.WriteLine("------------------------------------------------Query11----------------------------------------------------");
            var age = emp.Max(e => e.DOB);
            var q11 = emp.Count(e =>e.DOB==age);
                Console.WriteLine("The youngest count is "+q11);

            





            Console.Read();

        }
    }
}
