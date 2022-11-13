using System;
using System.Data;

namespace Program2
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
            /*
             * test case 0 n = 1
             * test case 1 n = 2
             * test case 2 n = 3
             * test case 3 n = 4
             * test case 4 n = 5
             * test case 5 n = -1
             */
            Console.WriteLine("Enter the number n");
            int n = Convert.ToInt32(Console.ReadLine());
            bool answer = true;
            if (n > 1)
            {
                double root_n = root(n);
                for (int i = 2; i <= root_n; i++)
                {
                    if (n % i == 0) { answer = false; break; }
                }
                Console.WriteLine(answer);
            }
            else
            {
                answer = false;
                Console.WriteLine(answer);
            }

            /*
             * test case 0 false
             * test case 1 true
             * test case 2 true
             * test case 3 false
             * test case 4 true
             * test case 5 false
             */
        }
    }
}