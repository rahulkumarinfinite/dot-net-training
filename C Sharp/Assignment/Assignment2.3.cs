using System;
/*
  Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

Test Data / input: 2

Expected Output :
Tuesday
*/

namespace Assignment2._3
{
    public enum day { sunday,monday,tuesday,wednesday,thursday,friday,saturday}; //initialise the day enumerations

    class Program
    {
        static void ReadDay(int a) //function
        {
            Console.WriteLine("the day is :"+Enum.GetName(typeof(day), a));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());  //taking the day
            ReadDay(a); //calling the function
            Console.Read();


        }
    }
}
