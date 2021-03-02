using System;
using System.Collections.Generic;

namespace DistributeCandy
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3657/
        static void Main(string[] args)
        {
            Console.WriteLine(DistributeCandies(new int[] { 1, 1, 2, 2, 3, 3 }));
            Console.WriteLine(DistributeCandies(new int[] { 1, 1, 2, 3 }));
            Console.WriteLine(DistributeCandies(new int[] { 6, 6, 6, 6 }));
        }
        public static int DistributeCandies(int[] candyType)
        {
            int max = candyType.Length / 2; //Max candies can eat
            HashSet<int> types = new HashSet<int>(); //Different type of candies
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
