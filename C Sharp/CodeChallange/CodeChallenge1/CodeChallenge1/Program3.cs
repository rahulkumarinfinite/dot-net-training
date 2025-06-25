using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Write a C# Sharp program to check the largest number among three given integers.
 
Sample Input:
1,2,3
1,3,2
1,1,1
1,2,2
Expected Output:
3
3
1
2
*/
namespace CodeChallenge1
{
    class Solution3
    {
        public int a, b, c,l;
        public void largest()
        {
            Console.WriteLine("enter the numbers");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
             l = ((a > b && a> c) ? a : (b > c ? b : c));
            Console.WriteLine("the output will be : "+l);
        }
    }
    class Program3
    {
        static void Main()
        {
            Solution3 solution3 = new Solution3();
            solution3.largest();
            Console.Read();
        }
    }
}
