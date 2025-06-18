using System;


namespace Assignment1Q4
{
    class Program
    {
        public void solution()
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The output is");
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine(a * i);
            }
        }
        static void Main(string[] args)
        {
            Program multi = new Program();
            multi.solution();
            Console.Read();
        }
    }
}
