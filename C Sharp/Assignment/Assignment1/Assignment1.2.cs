using System;


namespace Assignment1Q2
{
    class Program
    {
        //To check the number is positive o
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a > 0)
            {
                Console.WriteLine("{0} is positive number", a);
            }
            else if (a < 0)
                Console.WriteLine("{0} is negative number", a);
            else
                Console.WriteLine("Zero is neutral number");
            Console.Read();
        }
    }
}
