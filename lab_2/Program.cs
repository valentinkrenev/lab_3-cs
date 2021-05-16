using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var func = new RangeFunc();
            func.DrawTable(-1, 1, 0.4, 0.00000000000000001);
        }
    }
    class RangeFunc
    {
        public double Range(double eps, double x)
        {
            double sum = 0;
            double lastElement = 1;
            for (int n = 0; true; n++)
            {
                var element = (Pow(x, 2 * n + 1)) / (2 * n + 1);

                if (lastElement - element <= eps)
                    return sum;

                lastElement = element;
                sum += element;
            }
        }
        public void DrawTable(double a, double b, double step, double eps)
        {
            if (a < -1)
                Console.WriteLine("");

            if (b > 1)
                Console.WriteLine("");

            Console.WriteLine("    value    : arth value");
            
            for (double i = a; i < b; i += step)
                Console.WriteLine($"Arth : {i}  =  {Range(eps, i)}");
        }
    }
}
