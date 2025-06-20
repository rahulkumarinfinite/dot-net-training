using System;
using System.Linq;
//Write a program in C# to accept a word from the user and display the reverse of it. 

namespace Assignment2String2
{
    class Solution
    {
        public void Reverse(string s)
        {
           string str=new string(s.Reverse().ToArray());

            Console.WriteLine("The reverse of word will be "+str);

        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine("Input the word");
            string s = Console.ReadLine();
            solution.Reverse(s);
            Console.Read();
        }
    }
}
