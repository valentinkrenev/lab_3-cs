using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ArrayAlg.ModSum(new int[] { 1, 2, 3, 0, 1, 2, 3, 0, 1, 2 }));
            //Console.WriteLine(string.Join(',', ArrayAlg.EvenSort(new int[] { 1, 2, 3, 0, 1, 2, 3, 0, 1, 2 })));
            Console.WriteLine(string.Join(',', ArrayAlg.SwapMaxMin(new List<int> { 87, 324, 95, 6, 234, 23, 401, 3, 87 })));
            Console.WriteLine("Hello World!");
        }
    }

    class ArrayAlg
    {
        public static int Min(int[] array) => array.Min(Math.Abs);
        public static int ModSum(int[] array) => array.SkipWhile(x => x != 0).Sum(Math.Abs);
        public static int[] EvenSort(int[] array) => array.Select((value, index) => (value: value, isEven: index % 2 == 0)).OrderByDescending(x => x.isEven).Select(x => x.value).ToArray();

        public static int[] SwapMaxMin(List<int> array) => Swap(array, array.Max(), array.Min());
        public static int[] Swap(List<int> array, int a, int b)
        {
            var aIndex = array.IndexOf(a);
            array[array.IndexOf(b)] = a;
            array[aIndex] = b;
            return array.ToArray();
        }

        //TODO 3 - 4 tasks
    }
}
