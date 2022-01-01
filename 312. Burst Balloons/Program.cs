using System;

namespace _312._Burst_Balloons
{
    class Program
    {
        //https://leetcode.com/problems/burst-balloons/
        static void Main(string[] args)
        {
            Console.WriteLine(MaxCoins(new int[] { 1, 2, 3 }));            
        }

        public static int MaxCoins(int[] nums)
        {
            //Copy Array
            int n = nums.Length + 2; //Add Sentinels 1 to nums 
            int[] nums2 = new int[n];
            Array.Copy(nums, 0, nums2, 1, nums.Length);

            //Add Sentinels
            nums2[0] = 1; //Sentinel 1 before array
            nums2[n - 1] = 1; //Sentinel 1 after array

            int[,] cache = new int[n, n];

            return DP(cache, nums2, 1, n - 2);
        }

        public static int DP(int[,] cache, int[] nums, int l, int r)
        {
            //After burst all 
            if (r - l < 0) return 0;

            //if cached
            if (cache[l, r] > 0) return cache[l, r];

            int ans = 0;
            for(int i = l; i <= r; i++)
            {
                //num[i] is last to burst
                int gain = nums[l - 1] * nums[i] * nums[r + 1];
                //num[i] fixed - recurse on left and right
                int remaining = DP(cache, nums, l, i - 1) + DP(cache, nums, i + 1, r);
                ans = Math.Max(ans, remaining + gain);
            }
            //Add to cache
            cache[l, r] = ans;
            return ans;
        }
    }
}
