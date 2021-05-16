using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace lab_3_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input a");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Input b");
            int b = int.Parse(Console.ReadLine());

            MathEx.GCDex(a, b);

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
        public static int GCDex(int a, int b)
        {
            if (b == 0)
                throw new InvalidDataException("b = 0");


            var x = new int[] { a, 1, 0 };
            var y = new int[] { b, 0, 1 };
            var t = new int[] { 0, 0, 0 };
            Console.WriteLine("Ost\tX\tY\tChast");
            Console.WriteLine(x[0] + "\t" + x[1] + "\t" + x[2]);
            Console.WriteLine(y[0] + "\t" + y[1] + "\t" + y[2]);
            while (y[0] != 0)
            {
                var q = x[0] / y[0];
                t[0] = x[0] % y[0];
                t[1] = x[1] - q * y[1];
                t[2] = x[2] - q * y[2];
                Array.Copy(y, x, 3);
                Array.Copy(t, y, 3);
                Console.WriteLine(y[0] + "\t" + y[1] + "\t" + y[2] + "\t" + q);

            }

            return 0;
        }
    }
}
