using System;
using System.IO;

namespace lab_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random(234);
            for (int i = 0; i < 1000000; i++)
            {
                var b = rnd.Next(2, 13234004);
                if (TestGCD.GCD(i, b) != MathEx.GCD(i, b))
                {
                    throw new Exception($"{i} : {b}");
                }
            }
            Console.WriteLine(MathEx.GCD(19, 3));
        }
    }

    class TestGCD
    {
        public static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                while (b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                return a;
            }
        }
    }
    class MathEx
    {
        public static int GCD(int a, int b)
        {
            if (b == 0)
                throw new InvalidDataException("b = 0");

            int reminder = a % b;

            if (reminder == 0)
                return b;

            return GCD(b, reminder);
        }
    }
}
