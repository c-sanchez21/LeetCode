using System;
using System.Collections.Generic;

namespace _1695._Maximum_Erasure_Value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximumUniqueSubarray(new int[] { 4, 2, 4, 5, 6 }));
            Console.WriteLine(MaximumUniqueSubarray(new int[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }));
        }

        public static int MaximumUniqueSubarray(int[] nums)
        {
            int maxSum = 0;
            int l = 0, r = 0;
            HashSet<int> set = new HashSet<int>();
            int num, sum = 0;
            for(r = 0; r < nums.Length; r++)
            {
                num = nums[r];
                if (set.Contains(num))
                {
                    maxSum = Math.Max(sum, maxSum);
                    while (set.Contains(num) && l < r)
                    {
                        sum -= nums[l];
                        set.Remove(nums[l++]);
                    }
                }
                sum += num;
                set.Add(num);
            }
            maxSum = Math.Max(maxSum, sum);
            return maxSum;
        }
    }
}
