using System;
using System.Collections.Generic;

namespace _1200._Minimum_Absolute_Difference
{
    class Program
    {
        //https://leetcode.com/problemset/all/
        static void Main(string[] args)
        {
            PrintResults(MinimumAbsDifference(new int[] { 4, 2, 1, 3 }));
            PrintResults(MinimumAbsDifference(new int[] { 1, 3, 6, 10, 15 }));
            PrintResults(MinimumAbsDifference(new int[] { 3, 8, -10, 23,19,-4,-14,27 }));
        }

        public static void PrintResults(IList<IList<int>> res)
        {
            foreach (IList<int> set in res)
            {
                Console.Write("[");
                foreach (int x in set)
                    Console.Write("{0} ", x);
                Console.Write("] ");
            }
            Console.WriteLine();
        }

        public static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            
            List<IList<int>> res = new List<IList<int>>();

            //Sort the Array
            Array.Sort(arr);

            //Find the Minimum difference
            int minDiff = int.MaxValue;
            for(int i = 0; i < arr.Length-1; i++)
                minDiff = Math.Min(minDiff, arr[i + 1] - arr[i]);

            //Find the pair of integes that match the Minimum Difference 
            //And add to results
            for(int i = 0; i < arr.Length-1; i++)
            {
                if ((arr[i + 1] - arr[i]) == minDiff)
                    res.Add(new List<int>(new int[2] { arr[i], arr[i + 1] }));
            }

            //Retrun results
            return res;
        }

    }
}
