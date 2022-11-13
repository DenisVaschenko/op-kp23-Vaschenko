using System;
using System.Data;

namespace Program3
{
    class Program
    {
        /*
         * test case 0 x = 0, n= 0
         * test case 1 x = 1, n= 1
         * test case 2 x = 2, n= 2
         * test case 3 x = 3, n= 3
         * test case 4 x = 4, n= 4
         * test case 5 x = 5, n= 5
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number x");
            int x = Convert.ToInt32(Console.ReadLine());
            int fact_n = 1;
            double powered_x = 1;
            if (n >= 0)
            {
                for (int i = 2; i <= n; i++)
                {
                    fact_n *= i;
                }
                Console.WriteLine("factorial of number = " + fact_n);
            }
            else
            {
                Console.WriteLine("Unable to calculate factorial of number n");
            }
            if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    powered_x *= x;
                }
            }
            else
            {
                n = -n;
                for (int i = 0; i < n; i++)
                {
                    powered_x /= x;
                }
            }
            Console.WriteLine("Powered number = " + powered_x);
        }
        /*
         * test case 0 fact_n = 1, powered_x= 1
         * test case 1 fact_n = 1, powered_x= 1
         * test case 2 fact_n = 2, powered_x= 4
         * test case 3 fact_n = 6, powered_x= 27
         * test case 4 fact_n = 24, powered_x= 256
         * test case 5 fact_n = 120, powered_x= 3125
         */
    }
}