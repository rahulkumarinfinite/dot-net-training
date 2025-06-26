using System;

//program to check given two integers are same then return their sum triplet
namespace Assignment1Q5
{
    
    class Program
    {
        public static int sumOfTwo() // function to check given numbers are same and returning their sum
        {
            Console.WriteLine("Enter the first number");
            int a = Convert.ToInt32(Console.ReadLine()); // taking first number
            Console.WriteLine("Enter the second number"); // taking second number
            int b = Convert.ToInt32(Console.ReadLine());
            if (a != b) // condition checking
            {
                return a + b;
            }
            else
            {
                int c = 3 * (a + b);
                return c;
            }
            return 0;

        }
        static void Main(string[] args)
        {
            // calling the sumOfTwo ()
            int c =sumOfTwo();
            Console.WriteLine("The result is : " + c);
            Console.Read();

        }
    }
}
