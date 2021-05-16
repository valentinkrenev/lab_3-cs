using System;
using System.Collections.Generic;
using static lab_2_1.Program.Figures;
using static System.Math;

namespace lab_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawer = new Drawer();
            foreach (var val in drawer.Draw(1)) Console.WriteLine($"{val.Key} : {val.Value}");
        }

        class Drawer
        {
            public Dictionary<double, double> Draw(double step)
            {
                var res = new Dictionary<double, double>();

                for (double x = -10; x <= 3; x += step) res.Add(x, GetValue(x));

                return res;
            }

            private double GetValue(double x)
            {
                if (x >= -10 && x <= -6)
                    return BottomHalfCircle(2, x, -8, 2);
                if (x > -6 && x <= -4)
                    return Line(0, x, 2);
                if (x > -4 && x <= 2)
                    return Line(-(1d / 2d), x, 0);
                if (x > 2 && x <= 3)
                    return Line(1d, x, -3);

                throw new NotImplementedException();
            }
        }

        public static class Figures
        {
            public static double Line(double angleCoefficient, double x, double upSize) => angleCoefficient * x + upSize;
            public static double BottomHalfCircle(double radius, double x, double middleX, double middleY) => -Sqrt(Pow(radius, 2) - Pow((x - middleX), 2)) + middleY;
        }
    }
}
