using System;

 // Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)


namespace Assignment2Array3
{
    class Program
    {
        static void copyArray()
        {
            Console.WriteLine("Enter the size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Enter the array");
            for(int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] copyArr = new int[n];
            for(int i = 0; i < n; i++)
            {
                copyArr[i] = arr[i];
            }
            Console.WriteLine("The copy array will be");
            for(int i = 0; i < copyArr.Length; i++)
            {
                Console.WriteLine(copyArr[i]);
            }
        }
        static void Main(string[] args)
        {
            copyArray();
            Console.Read();
        }
    }
}
