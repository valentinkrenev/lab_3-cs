using System;
using System.Linq;
using System.Numerics;

namespace lab_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var val in Enumerable.Range(1, 100))
            {
                var test = Mod(val, 13, 13);
                Console.WriteLine(test);
            }
            Console.WriteLine("Hello World!");
        }

        static int Mod(int value, int mod, int pow)
        {
            if (mod != pow)
                throw new Exception("Степень не равна делителю");

            if (!IsPrime(pow))
                throw new Exception("Число не простое");

            return value % mod;
        }
        static bool IsPrime(long n)
        {
            for (long i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
