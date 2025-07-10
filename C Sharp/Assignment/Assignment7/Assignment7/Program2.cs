using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a query that returns words starting with letter 'a' and ending with letter 'm'.


//Expected input and output
//"mum", "amsterdam", "bloom" → "amsterdam"

namespace Assignment7
{
    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter the size of words pool");
            int a = int.Parse(Console.ReadLine());
            string[] words = new string[a];
            Console.WriteLine("Enter the word");
            for(int i = 0; i < a; i++)
            {
                words[i] = Console.ReadLine();
            }

            var result = words
            .Where(word => word.StartsWith("a") ||
            word.EndsWith("m"));
            Console.WriteLine("The updated words pool will be");

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            Console.Read();

        }
    }
}
