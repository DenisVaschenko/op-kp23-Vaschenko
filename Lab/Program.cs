using System;

namespace Practice3
{
    class Project
    {
        static void Main(string[] args)
        {
            /* case 1 n = 0
             * case 2 n = 1
             * case 3 n = 9
             * case 4 n = 10
             */

            Console.WriteLine("Enter number n");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine("sum of numbers equals " + sum);
            /* case 1 sum =0
             * case 2 sum = 1
             * case 3 sum = 45
             * case 4 sum = 55
             */
        }
    }
}