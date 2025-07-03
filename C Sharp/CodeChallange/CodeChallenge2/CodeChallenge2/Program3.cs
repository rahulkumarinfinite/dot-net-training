using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative.
 * Handle the exception in the calling code
*/
namespace CodeChallenge2
{

    class Question3
    {
       
        public void CheckIfNegative(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number are negative.");
            }
            Console.WriteLine($"The number {number} is positive.");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter an number ");
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);
                Question3 a = new Question3();
                a.CheckIfNegative(number);
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
 
            }

            Console.WriteLine("Program has completed execution.");
            Console.Read();
        }
    }
}
