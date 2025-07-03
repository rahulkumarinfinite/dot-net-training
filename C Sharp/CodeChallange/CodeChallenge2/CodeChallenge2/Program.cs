using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  /*  Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade)
   *  which takes grade as an input and checks whether student passed the course or not.  
 
Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false.
  For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 
Test the above by creating appropriate objects

*/

namespace CodeChallenge2
{
    abstract class Student
    {
        string Name;
        int StudentId;
         float Grade;
        public Student(string n,int s,float g)
        {
            this.Name = n;
            this.StudentId = s;
            this.Grade = g;
        }
        public abstract bool IsPassed(double grade);
    }
    class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, float grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class graduate : Student
    {
        public graduate(string name, int studentId, float grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the grade of student");
            float a = float.Parse(Console.ReadLine());
            Undergraduate under = new Undergraduate("Rahul", 46, a);
            graduate gread = new graduate("Rahul", 46, a);
            Console.WriteLine("Grade of student {0}", a);
            bool b1 = under.IsPassed(a);
            bool b2 = gread.IsPassed(a);
            Console.WriteLine("In Undergraduate pass "+b1);
            Console.WriteLine("In graduate pass "+b2);
            Console.Read();
        }
    }
}
