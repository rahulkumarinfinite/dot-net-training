using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the two number");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine("Given number are equal");
            }
            else
            {
                Console.WriteLine("Given number are not equal");
            }
            Console.Read();
        }
    }
}
