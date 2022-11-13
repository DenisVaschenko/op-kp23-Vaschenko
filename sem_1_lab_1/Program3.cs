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
            int n = 0;
            Console.WriteLine("Enter the number x");
            int x = 0;
            int fact_x = 0, powered_x = 0;
            Console.WriteLine("factorial of number = " + fact_x);
            Console.WriteLine("Powered number = " + powered_x);
        }
        /*
         * test case 0 fact_x = 1, powered_x= 1
         * test case 1 fact_x = 1, powered_x= 1
         * test case 2 fact_x = 2, powered_x= 4
         * test case 3 fact_x = 6, powered_x= 27
         * test case 4 fact_x = 24, powered_x= 256
         * test case 5 fact_x = 120, powered_x= 3125
         */
    }
}