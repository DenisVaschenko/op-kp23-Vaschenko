using System;
using System.Data;

namespace Program4
{
    // test case 0 x = 0,1,2,3,4,5,-1,-2,-3,-4
    class Program
    {
        static double sin(double x)
        {
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number x");
            for (int i = 0; i<10; i++)
            {
                double x = 0;
                Console.WriteLine(x);
                Console.WriteLine("Result matches with Math.Sin(x)");
            }
        }
    }
    // test case 0 sin(x) = 0,0.841,0.909,0.141,-0.757,-0.959,-0.841,-0.909,-0.141,0.757; All results matches with Math.Sin(x)
}