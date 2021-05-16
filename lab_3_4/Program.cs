﻿using System;
using System.IO;

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
