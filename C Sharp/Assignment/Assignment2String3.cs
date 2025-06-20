using System;
using System.Linq;
//Write a program in C# to accept two words from user and find out if they are same.


namespace Assignment2String3
{
    class Solution
    {
        public void sameOrNot(string s1, string s2)
        {
            int a = s1.GetHashCode();
            int b = s2.GetHashCode();
            if (a == b)
                Console.WriteLine("The word are the same");
            else
                Console.WriteLine("The word are not same");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first word");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter the second word");
            string s2 = Console.ReadLine();
            Solution solution = new Solution();
            solution.sameOrNot(s1, s2);
            Console.Read();
        }
    }
}
