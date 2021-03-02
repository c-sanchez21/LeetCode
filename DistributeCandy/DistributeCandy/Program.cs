using System;
using System.Collections.Generic;

namespace DistributeCandy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DistributeCandies(new int[] { 1, 1, 2, 2, 3, 3 }));
            Console.WriteLine(DistributeCandies(new int[] { 1, 1, 2, 3 }));
            Console.WriteLine(DistributeCandies(new int[] { 6, 6, 6, 6 }));
        }
        public static int DistributeCandies(int[] candyType)
        {
            int max = candyType.Length / 2;
            HashSet<int> types = new HashSet<int>();
            for (int i = 0; i < candyType.Length; i++)
            {
                types.Add(candyType[i]);
                if (types.Count == max)
                    break;
            }
            return Math.Min(types.Count, max);
        }
    }
}
