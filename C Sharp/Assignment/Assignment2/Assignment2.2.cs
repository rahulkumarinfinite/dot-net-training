using System;
/* Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

Test Data:
Enter a digit: 25

Expected Output:
25 25 25 25
25252525
25 25 25 25
25252525
*/
namespace Assignment2._2
{
    class solution
    {
     public static void displayPattern(int a)
        {
         for(int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        Console.Write("{0} ", a);
                    }
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write("{0}", a);
                    }
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The pattern is:");
            solution.displayPattern(a);
            Console.Read();
        }
    }
}
