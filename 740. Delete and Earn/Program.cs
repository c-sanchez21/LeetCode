using System;
using System.Collections.Generic;
using System.Linq;

namespace _740._Delete_and_Earn
{
    class Program
    {
        //https://leetcode.com/problems/delete-and-earn/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(DeleteAndEarn(new int[] { 3, 4, 2 }));
            Console.WriteLine(DeleteAndEarn(new int[] { 2, 2, 3, 3, 3, 4 }));
            Console.WriteLine(DeleteAndEarn(new int[] { 1 }));
            Console.WriteLine(DeleteAndEarn(new int[] { 1,2,3,4,5}));
            Console.WriteLine(DeleteAndEarn(new int[] { 8, 3, 4, 7, 6, 6, 9, 2, 5, 8, 2, 4, 9, 5, 9, 1, 5, 7, 1, 4 }));
        }


        //Frequency Hashmap
        public static Dictionary<int, int> frq = new Dictionary<int, int>();
        //Memoization Cache
        public static Dictionary<int, int> cache = new Dictionary<int, int>();

        //Dyanmic Programming
        public static int DeleteAndEarn(int[] nums)
        {
            //Check invalid input
            if (nums == null || nums.Length == 0) return 0;

            //Initialize Hashmaps
            frq = new Dictionary<int, int>();
            cache = new Dictionary<int, int>();

            int hi = -1;//Highest Number
            foreach (int val in nums)
            {
                //Add number and possible points to Frequency map
                if (!frq.ContainsKey(val))
                    frq.Add(val, 0);
                frq[val] += val;

                //Update Highest number if needed
                if (val > hi) hi = val;
            }
            return MaxPoints(hi);
        }

        public static int MaxPoints(int num)
        {
            //Base Cases
            if (num <= 0) return 0;
            if (num == 1) return frq.ContainsKey(1) ? frq[1] : 0;

            //Return value from cache if it exists
            if (cache.ContainsKey(num)) return cache[num];

            //Possible gain from the current num 
            int plus = frq.ContainsKey(num) ? frq[num] : 0;

            //Recursive call to find the max possible points
            int max = Math.Max(MaxPoints(num - 1), (MaxPoints(num - 2) + plus));
            
            //Cache and return the result
            cache.Add(num, max);
            return max;
        }
    }
}
