using System;
/*
 Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )

-Pass the details of student like rollno, name, class, SEM, branch in constructor

-For marks write a method called GetMarks() and give marks for all 5 subjects

-Write a method called displayresult, which should calculate the average marks

-If marks of any one subject is less than 35 print result as failed
-If marks of all subject is >35,but average is < 50 then also print result as failed
-If avg > 50 then print result as passed.

-Write a DisplayData() method to display all object members values.
*/

namespace Assignment3
{
    class Student
    {
        public string name;
        public int Roll_no;
        public string Class;
        public int semester;
        public string branch;
        public int[] marks = new int[5];
        public Student(int Roll,string nam,string class1,int sem,string br)
        {
            name = nam;
            Roll_no = Roll;
            Class = class1;
            semester = sem;
            branch = br;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter the marks of student");
            for(int i = 0; i < 5; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int sum = 0;
            for(int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    Console.WriteLine("{0} is failed", name);
                }
                sum = sum + marks[i];
            }
            int avg = sum / 5;
            Console.WriteLine("The average marks will be : "+avg);
            if (avg > 50)
                Console.WriteLine("{0} is passed", name);
            foreach(int i in marks)
            {
                if(i>35 && avg < 50)
                {
                    Console.WriteLine("{0} is failed", name);
                    break;
                }

            }
        }
        public void DisplayData()
        {
            Console.WriteLine("Name of student = " + name + ", class = " + Class + ", Roll Number = " + Roll_no +
                ", Semester = " + semester + ", Branch = " + branch);
            DisplayResult();
        }
    }
    class Program2
    {
        static void Main()
        {
            Student stu = new Student(200192153, "Rahul Kumar", "BTech", 8, "Computer Science");
            stu.GetMarks();
            stu.DisplayData();
            Console.Read();

        }
    }
}
