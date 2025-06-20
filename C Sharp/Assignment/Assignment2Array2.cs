using System;
/*
Write a program in C# to accept ten marks and display the following
	a.	Total
	b.	Average
	c.	Minimum marks
	d.	Maximum marks
	e.	Display marks in ascending order
	f.	Display marks in descending order
*/
namespace Assignment2Array2
{
    class Solution
    {
        public static void MarksProperty()
        {
            Console.WriteLine("Enter the number of subject");
            int sub = Convert.ToInt32(Console.ReadLine());
            int[] marks = new int[sub];
            Console.WriteLine("Enter the marks of subjects");
            for(int i = 0; i < sub; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0, max = marks[0], min = marks[0];
            for(int i = 0; i < marks.Length; i++)
            {
                sum += marks[i];
                if (marks[i] > max)
                    max = marks[i];
                if (marks[i] < min)
                    min = marks[i];
            }
            Console.WriteLine("The average marks will be " + sum / sub);
            Console.WriteLine("The maximum marks will be " + max);
            Console.WriteLine("The minimum marke will be " + min);
            int[] marksCopy = new int[sub];
            marks.CopyTo(marksCopy, 0);
            Array.Sort(marksCopy);
            Console.WriteLine("The ascending order of array will be");
            for(int i = 0; i < sub; i++)
            {
                Console.Write(marksCopy[i]+" ");
            }
            Console.WriteLine();
            Array.Reverse(marksCopy);
            Console.WriteLine("The descending order of array will be");
            for (int i = 0; i < sub; i++)
            {
                Console.Write(marksCopy[i] + " ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution.MarksProperty();
            Console.Read();
        }
    }
}
