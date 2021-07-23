using System;

namespace Partition_Array_into_Disjoint_Intervals
{
    class Program
    {
        //https://leetcode.com/problems/partition-array-into-disjoint-intervals/
        static void Main(string[] args)
        {
            Console.WriteLine(PartitionDisjoint(new int[] { 5, 0, 3, 8, 6 }));//3
        }

        public static int PartitionDisjoint(int[] nums)
        {
            //Base Case
            if (nums == null || nums.Length == 0) return -1;
            int n = nums.Length; 

            int[] maxleft = new int[n];
            int[] minright = new int[n];

            int num = nums[0];
            for (int i = 0; i < n; ++i)
            {
                num = Math.Max(num, nums[i]);
                maxleft[i] = num;
            }

            num = nums[n - 1];
            for (int i = n - 1; i >= 0; --i)
            {
                num = Math.Min(num, nums[i]);
                minright[i] = num;
            }

            for (int i = 1; i < n; ++i)
                if (maxleft[i - 1] <= minright[i])
                    return i;

            return -1; 
        }
    }


}
