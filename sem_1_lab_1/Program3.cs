using System;
using System.Data;

namespace Program3
{
    class Program
    {
        static double root(int sqr_x)
        {
            double left = 0, right = sqr_x;
            double x = 0;
            while (Math.Abs(sqr_x - x*x) > 0.1)
            {
                x = (left +right) / 2;
                if (x * x == sqr_x) { break; }
                else if (x * x < sqr_x) { left = x; }
                else { right = x; }
            }
            return x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number n");
            int n = 0;
            Console.WriteLine("Enter the number x");
            int x = 0;
            int fact_x = 0, powered_x = 0;
            Console.WriteLine("factorial of number = " + fact_x);
            Console.WriteLine("Powered number = " + powered_x);
        }
    }
}