using System;
using System.Collections.Generic;

namespace _1431._Kids_With_the_Greatest_Number_of_Candies
{
    class Program
    {
        //https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
        static void Main(string[] args)
        {
            //Example 1: 
            IList<bool> results = KidsWithCandies(new int[] { 12, 1, 12 }, 10);
            Console.WriteLine("{0}", string.Join(" ", new List<bool>(results).ConvertAll(i => i.ToString()).ToArray()));
        }

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            //Find the max value - the kid with greatest amount of candies
            int max = 0;
            for (int i = 0; i < candies.Length; i++)
                max = Math.Max(max, candies[i]);

            max -= extraCandies;//Saves calculations

            //Find if giving the ith kid the extra candies will make them the one with most candies
            List<bool> results = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
                results.Add((candies[i] >= max) ? true : false);
            return results;
        }

        public static IList<bool> KidsWithCandies2(int[] candies, int extraCandies)
        {
            //Find the max value - the kid with greatest amount of candies
            int max = 0;
            for (int i = 0; i < candies.Length; i++)
                max = Math.Max(max, candies[i]);

            //Find if giving the ith kid the extra candies will make them the one with most candies
            List<bool> results = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
                results.Add((candies[i] + extraCandies >= max) ? true : false);

            return results;
        }


    }
}
