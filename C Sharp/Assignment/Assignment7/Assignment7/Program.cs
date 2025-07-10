using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input [7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900

namespace Assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of number array");
            int a = int.Parse(Console.ReadLine());
            int[] nums = new int[a];
            Console.WriteLine("Enter the number");
            for(int i = 0; i < a; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            var result = nums
            .Select(n => new { Number = n, Square = n * n })
            .Where(x => x.Square > 20);
            Console.WriteLine("The output will be");
            foreach (var item in result)
            {
                Console.WriteLine(item.Number+" "+item.Square);
            }
            Console.Read();
        }
    }

}
    

