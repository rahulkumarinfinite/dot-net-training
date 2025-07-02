using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Create a class called Scholarship which has a function Public void Merit()
 * that takes marks and fees as an input. 
If the given mark is >= 70 and <=80, then calculate scholarship amount as 20%
of the fees
If the given mark is > 80 and <=90, then calculate scholarship amount as 
30% of the fees
If the given mark is >90, then calculate scholarship amount as 50% of the fees.
In all the cases return the Scholarship amount, else throw an user exception
*/

namespace Assignment5
{
    public class ExceptionHandling : ApplicationException
    {
        public ExceptionHandling(string s) : base(s) {

        }
    }
    class Scholarship
    {
        

        public void Merit(int m1, float f1)
        {
            Console.WriteLine("Marks can not be greater than 100");
            Console.WriteLine("Marks is {0} and fee is {1}", m1, f1);
            if (m1 >= 70 && m1 <= 80)
            {
                Console.WriteLine("Marks can not be greater than 100");
                Console.WriteLine("Marks is {0} and fee is {1}", m1, f1);
                float s = f1 * 0.2f;
                Console.WriteLine("the amount of scholarship is " + s);
            }
            else if (m1 > 80 && m1 <= 90)
            {
                float s = f1 * 0.3f;
                Console.WriteLine("the amount of scholarship is " + s);
            }
            else if (m1 > 90)
            {
                float s = f1 * 0.5f;
                Console.WriteLine("the amount of scholarship is " + s);
            }
            else
            {
                throw new ExceptionHandling("You are not applicable");
            }
        }

    }
    class Question2
    {
        static void Main()
        {
            Scholarship scholarship = new Scholarship();
            try
            {
                scholarship.Merit(95, 5000);
            }
            catch (ExceptionHandling e)
            {
                Console.WriteLine("Sorry!" + e.Message);
            }
            Console.Read();
        }
    }
}
