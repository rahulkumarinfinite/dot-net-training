using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program to find the Sum and the Average points scored by the teams in the IPL.
//Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that
//takes no.of matches as input and accepts that many scores from the user. The function should then return
//the Count of Matches, Average and Sum of the scores.

namespace CodeChallenge3
{
    class CricketTeam
    {
        public Tuple<int ,float ,int> Pointscalculation(int no_of_matches)
        {
            int[] s = new int[no_of_matches];
            int sum = 0;
            Console.WriteLine("Enter the score of matches");
            for(int i=0;i< no_of_matches; i++)
            {
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine($"the score of {i + 1} match is " + a);
                s[i] = a;
                sum += s[i];

            }
            float Average = sum / no_of_matches;
            Tuple<int, float, int> result = Tuple.Create(no_of_matches, Average, sum);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of matches ");
            int n = int.Parse(Console.ReadLine());
            CricketTeam team = new CricketTeam();
            Tuple<int, float, int> res = team.Pointscalculation(n);
            Console.WriteLine($"The sum of the scores is {res.Item3}, number of matchs is {res.Item1} and average is {res.Item2}");
            Console.Read();
           
        }
    }
}
