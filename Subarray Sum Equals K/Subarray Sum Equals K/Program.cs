using System;
using System.Collections.Generic;

namespace Subarray_Sum_Equals_K
{
    class Program
    {
        static void Main(string[] args)
        {
            int sub = SubarraySum(new int[] { 0, 3, -3,3}, 3);
            Console.WriteLine(sub);
        }

        public static int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            Dictionary<int, int> sumCounts = new Dictionary<int, int>();
            sumCounts.Add(0, 1);
            for(int i =0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sumCounts.ContainsKey(sum - k))
                    count += sumCounts[sum - k];
                if (!sumCounts.ContainsKey(sum))
                    sumCounts.Add(sum, 0);
                sumCounts[sum]++;
            }
            return count;
        }
    }
}
