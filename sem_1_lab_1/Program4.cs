using System;
using System.Data;

namespace Program4
{
    // test case 0 x = 0,1,2,3,4,5,-1,-2,-3,-4
    class Program
    {
        static double sin(double x)
        {
            double answer = x, a = x;

            for (int i = 1; i<20; i++)
            {
                a *= -1 * x * x / (2 * i * (2 * i + 1));
                answer += a;
            }
            return answer;
        }
        static void Main(string[] args)
        { 
            for (int i = 0; i<10; i++)
            {
                Console.WriteLine("Enter the number x");
                double x = Convert.ToDouble(Console.ReadLine());
                if (Math.Abs(sin(x) - Math.Sin(x)) <0.0001)
                {
                    Console.WriteLine("{0:F3}",sin(x));
                    Console.WriteLine("Result matches with Math.Sin(x)");
                }
                else
                {
                    Console.WriteLine("Result doesn't match with Math.Sin(x)");
                }
            }
        }
    }
    // test case 0 sin(x) = 0,0.841,0.909,0.141,-0.757,-0.959,-0.841,-0.909,-0.141,0.757; All results matches with Math.Sin(x)
}