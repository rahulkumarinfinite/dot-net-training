using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * . Write a C# Sharp program to remove the character at a given position in the string. 
 * The given position will be in the range 0..(string length -1) inclusive.
 
Sample Input:
"Python", 1
"Python", 0
"Python", 4
Expected Output:
Pthon
ython
Pythn
 */

namespace CodeChallenge1
{
    class Solution1
    {
        public string str;
        public void remove()
        {
            Console.WriteLine("input the string");
            str = Console.ReadLine();
            Console.WriteLine("input the position");
            int a = int.Parse(Console.ReadLine());

            str = str.Remove(a, 1);

            Console.WriteLine("The output will be : ");
            Console.WriteLine(str);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution1 solution1 = new Solution1();
            solution1.remove();
            Console.Read();
        }
    }
}
