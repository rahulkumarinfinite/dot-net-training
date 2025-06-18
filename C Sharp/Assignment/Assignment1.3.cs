using System;


namespace Assignment1Q3
{
    class Program
    {
        public static void calculator()
        {
            Console.WriteLine("Enter the first number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operation");
            char ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int b = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case '+':
                    Console.WriteLine("The output is {0}", a + b);
                    break;
                case '-':
                    Console.WriteLine("The output is {0}", a - b);
                    break;
                case '*':
                    Console.WriteLine("The output is {0}", a * b);
                    break;
                case '/':
                    Console.WriteLine("The output is {0}", a/b);
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program.calculator();
            Console.Read();
        }
    }
}
