using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// Write a program in C# Sharp to count the number of lines in a file.
namespace Assignment_6
{
    class Program2
    {static void Main()
        {
            FileStream f1 = new FileStream("C:\\Users\\rahulkumar\\source\\repos\\Assignment@6\\output2.txt", FileMode.Open, FileAccess.Read);
         


            int lineCount = 0;

            StreamReader reader = new StreamReader(f1);
            string[] linesRead = File.ReadAllLines("C:\\Users\\rahulkumar\\source\\repos\\Assignment@6\\output2.txt");
            foreach(var item in linesRead)
            {
                Console.WriteLine(item);
            }

            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            Console.WriteLine("Number of lines in the file: " + lineCount);
            Console.Read();


        }
    }
}
