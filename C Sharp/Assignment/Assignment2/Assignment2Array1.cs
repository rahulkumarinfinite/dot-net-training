using System;
/*
    Write a  Program to assign integer values to an array  and then print the following
	a.	Average value of Array elements
	b.	Minimum and Maximum value in an array 
*/

namespace ConsoleApp2
{
    class Solution
    {
        public void ArrayOperation()
        {
            Console.WriteLine("Enter the size of array");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[a];
            Console.WriteLine("Enter the Array");
            for(int i = 0; i < a; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum=0, max = arr[0], min = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                sum =sum+ arr[i];
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
            Console.WriteLine("The average value of array element is " + sum / arr.Length);
            Console.WriteLine("The maximum value of array is {0} and the minimum value is {1}",max, min);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.ArrayOperation();
            Console.Read();
        }
    }
}
