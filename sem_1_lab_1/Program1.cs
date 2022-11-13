using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            // case 0 x0 = 4.6; xn = 5.8; n = 6
            Console.WriteLine("Enter the number x0");
            double x0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the number xn");
            double xn = Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Enter the number n");
            double n = Convert.ToDouble(Console.ReadLine());
            double x = 0, y = 0;
            double d = 1.3;
            for (int i = 0; i<=n; i++)
            {
                x = x0 + i * (xn - x0) / n;
                y = x * x * x * x + Math.Cos(2 + x * x * x - d);
                Console.WriteLine("x = {0:F3}; y = {1:F3}", x, y);
            }
            
            // case 0 x= 4.6, 4.8, 5, 5.2, 5.4, 5.6, 5.8; y= 446.947, 530.609, 625.999, 730.164, 850.773, 984.376, 1132.162
        }
    }
}