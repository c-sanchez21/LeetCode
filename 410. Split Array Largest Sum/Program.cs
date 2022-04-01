using System;

namespace _410._Split_Array_Largest_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SplitArray(new int[] { 7, 2, 5, 10, 8 }, 2));
            Console.WriteLine(SplitArray(new int[] { 1, 2, 3, 4, 5 }, 2));
            Console.WriteLine(SplitArray(new int[] { 1, 4, 4 }, 3));
        }

        static int[,] cache = new int[1001, 51];

        private static int GetMinMaxSplitSum(int[] prefixSum, int idx, int subArrayCount)
        {
            int n = prefixSum.Length - 1;

            //If cahced - return cache
            if (cache[idx, subArrayCount] != -1) return cache[idx, subArrayCount];

            //Base Case: only 1 subArray left - return sum of remaining
            if(subArrayCount == 1)
            {
                cache[idx, subArrayCount] = prefixSum[n] - prefixSum[idx];
                return cache[idx, subArrayCount];
            }

            int minMaxSplitSum = int.MaxValue;
            for(int i =idx; i <= n-subArrayCount; i++)
            {
                int firstSplitSum = prefixSum[i + 1] - prefixSum[idx];

                int maxSplitSum = Math.Max(firstSplitSum, GetMinMaxSplitSum(prefixSum, i + 1, subArrayCount - 1));
                minMaxSplitSum = Math.Min(minMaxSplitSum, maxSplitSum);
                if (firstSplitSum >= minMaxSplitSum) break;
            }

            cache[idx, subArrayCount] = minMaxSplitSum;
            return cache[idx, subArrayCount];
        }

        public static int SplitArray(int[] nums, int m)
        {
            //Initialize Cache 
            for (int i = 0; i <= 1000; i++)
                for (int j = 0; j <= 50; j++)
                    cache[i, j] = -1;

            int n = nums.Length;
            int[] prefixSum = new int[n + 1];

            for (int i = 0; i < n; i++)
                prefixSum[i + 1] = prefixSum[i] + nums[i];

            return GetMinMaxSplitSum(prefixSum, 0, m);
        }


    }
}
