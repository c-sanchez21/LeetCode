using System;

namespace _198._House_Robber
{
    class Program
    {
        //https://leetcode.com/problems/house-robber/
        static void Main(string[] args)
        {
            Console.WriteLine(Rob(new int[] { 1, 2, 3, 1 }));//4
            Console.WriteLine(Rob(new int[] { 2, 7, 9, 3, 1 }));//12 
        }

        //Cache for Memoization
        private static int[] cache;

        public static int Rob(int[] nums)
        {
            //Initialize cache to -1
            cache = new int[100];
            for (int i = 0; i < cache.Length; i++)
                cache[i] = -1;

            //Find solution - Utilizes Dynamic Programming
            return RobSub(0, nums);
        }

        public static int RobSub(int i, int[] nums)
        {
            //Base case no more houses left to examine
            if (i >= nums.Length)
                return 0;

            //If already cached - return cache value
            if (cache[i] > -1)
                return cache[i];

            //Utilize Dynamic Programming to find solution
            int ans = Math.Max(RobSub(i + 1, nums), RobSub(i + 2, nums) + nums[i]);

            //Store current answer in cache
            cache[i] = ans;

            //Return answer
            return ans;
        }
    }
}
