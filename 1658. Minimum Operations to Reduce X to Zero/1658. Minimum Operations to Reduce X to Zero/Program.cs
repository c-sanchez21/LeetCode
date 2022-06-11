using System;

namespace _1658._Minimum_Operations_to_Reduce_X_to_Zero
{
    internal class Program
    {
        //https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/
        static void Main(string[] args)
        {
            Console.WriteLine(MinOperations(new int[] { 1, 1, 4, 2, 3 }, 5));
        }

        public static int MinOperations(int[] nums, int x)
        {
            int cur = 0;
            foreach (int num in nums)
                cur += num;
            int n = nums.Length;
            int min = int.MaxValue;
            int l = 0;
            for(int r = 0; r < n; r++)
            {
                cur -= nums[r];
                while(cur < x && l <= r)
                    cur += nums[l++];
                if (cur == x)
                    min = Math.Min(min, (n - 1 - r) + l);
            }
            return (min == int.MaxValue) ? -1 : min;
        }
    }
}
