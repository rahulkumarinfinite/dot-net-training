
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// Write a program in C# Sharp to create a file and write an array of strings to the file.
namespace Assignment6
{
    class Question
    {
        static void Main(string[] args)
        {
            BinaryWriter w = new BinaryWriter(File.Open("C:\\Users\\rahulkumar\\source\\repos\\Assignment@6\\output.txt", FileMode.Create, FileAccess.Write));
            string[] res =
            {
                "i am Rahul ",
                "i am infinite employee",
                "i am very happy"
            };
            foreach (var item in res)
            {

                w.Write(item);
            }
            Console.WriteLine("File is created");

        
            Console.Read();

        }
    }
}