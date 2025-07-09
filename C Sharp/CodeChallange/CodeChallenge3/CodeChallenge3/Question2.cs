using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a class Box that has Length and breadth as its members. Write a function that adds 2
//box objects and stores in the 3rd. Display the 3rd object details. Create a Test class to execute the above.

namespace CodeChallenge3
{
    class Box
    {
        public int length;
        public int breadth;
        public Box(int l,int b)
        {
            this.length = l;
            this.breadth = b;
        }
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.length + b2.length, b1.breadth + b2.breadth);
        }

    }
    class Test:Box
    {
     public Test(int length,int breadth):base(length,breadth)
        {
            Console.WriteLine($"The length of new box is {length} and breadth is {breadth}");
        }
    }
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter the Length and Breadth of first box");
            int l1 = int.Parse(Console.ReadLine());
            int b1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Length and Breadth of second box");
            int l2 = int.Parse(Console.ReadLine());
            int b2 = int.Parse(Console.ReadLine());
            Box box1 = new Box(l1, b1);
            Box box2 = new Box(l2, b2);
            Box box3 = box1 + box2;
            Test t = new Test(box3.length,box3.breadth);
            Console.Read();

        }
    }
}
