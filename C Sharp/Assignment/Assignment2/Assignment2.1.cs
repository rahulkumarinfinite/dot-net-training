using System;

// Write a C# Sharp program to swap two numbers.
namespace Assignment2._1
{
    class Solution 
    {
        public void swap() //function of the calculation
        {
            int c;

            Console.WriteLine("Enter the first numbers");
            int a = Convert.ToInt32(Console.ReadLine()); //taking the first number
            int b = Convert.ToInt32(Console.ReadLine()); //taking the second number
            c = a; //copy the value of first number into the another variable 
            a = b; //copy the value of second number into the first number
            b = c; //copy the value of first number into the second number
            Console.WriteLine("numbers are swaped");
            Console.WriteLine(a); //print the first number
            Console.WriteLine(b); //print the second number

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
         Solution solution= new Solution(); //calling the class solution
            solution.swap(); //using the swap function 
            Console.Read();

        }
    }
}
