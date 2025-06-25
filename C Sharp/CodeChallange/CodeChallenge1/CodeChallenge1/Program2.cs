using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Write a C# Sharp program to exchange the first and last characters in a given
 * string and return the new string.
 
Sample Input:
"abcd"
"a"
"xy"
Expected Output:
 
dbca
a
yx
*/
namespace CodeChallenge1
{
    class Solution2
    {
        public string str { get; set; }
        public void exchange()
        {
            Console.WriteLine("enter the string");
            str = Console.ReadLine();
            int a = str.Length;
         

           string str3 = Convert.ToString(str[a - 1]);
            string str2=Convert.ToString(str[0]);
            string str4 = str.Substring(1, a - 2);

           
            Console.WriteLine(str3+str4+str2);











            

        }
    }

    class Program2
    {
        static void Main()
        {
            Solution2 solution2 = new Solution2();
            solution2.exchange();
            Console.Read();
        }
    }
}
