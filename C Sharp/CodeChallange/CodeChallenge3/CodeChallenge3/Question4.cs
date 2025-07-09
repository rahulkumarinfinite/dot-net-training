using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a console program that uses delegate object as an argument to call Calculator Functionalities
//like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user.
//You should display all the return values accordingly.
namespace CodeChallenge3

{
    class Calculator
    {
        public delegate int calculator(int a, int b);
        public static int add(int a, int b) => a + b;
        public static int subs(int a, int b) => a - b;
        public static int multi(int a, int b) => a * b;
        public static int PerformOperation(calculator c, int x, int y)
        {
            return c(x, y);
        }


    }
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("Enter the number ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Calculator cal = new Calculator();

           
            Calculator.calculator s = new Calculator.calculator(Calculator.subs);
            Calculator.calculator m = new Calculator.calculator(Calculator.multi);
            Calculator.calculator a = new Calculator.calculator(Calculator.add);

           
            int sum = Calculator.PerformOperation(a, x, y);
            int difference = Calculator.PerformOperation(s, x, y);
            int product = Calculator.PerformOperation(m, x, y);
            Console.WriteLine($"sum = {sum} difference = {difference} multiplication = {product}");
            Console.Read();

        }
    }
}
