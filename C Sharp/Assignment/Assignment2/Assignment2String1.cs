using System;
//Write a program in C# to accept a word from the user and display the length of it.

namespace Assignment2String1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter the word");
            str = Console.ReadLine();
            int len = str.Length;
            Console.WriteLine("The length of word is " + len);
            Console.Read();
        }
    }
}
