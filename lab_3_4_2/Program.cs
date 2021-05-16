using System;
using System.IO;
using System.Numerics;


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

            Console.WriteLine(MathEx.GCD(a, b));
            //var rnd = new Random(234);
            //for (int i = 0; i < 1000000; i++)
            //{
            //    var b = rnd.Next(2, 13234004);
            //    if (TestGCD.GCD(i, b) != MathEx.GCD(i, b))
            //    {
            //        throw new Exception($"{i} : {b}");
            //    }
            //}
            //Console.WriteLine(MathEx.GCD(19, 3));
        }
    }
  
    class TestGCD
    {



        public static int GCD(int a, int b)
        {
            int q = 0;
            int[] x = new int[] {a, 0, 0};
            int[] y = new int[] {0, b, 0};
            int[] t = new int[] {0, 0, 0};

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