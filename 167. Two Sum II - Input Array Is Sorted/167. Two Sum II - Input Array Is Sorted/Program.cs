using System;

namespace _167._Two_Sum_II___Input_Array_Is_Sorted
{
    internal class Program
    {
        //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(",",TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(String.Join(",", TwoSum(new int[] { 2, 3, 4 }, 6)));
            Console.WriteLine(String.Join(",", TwoSum(new int[] { -1, 0 }, -1)));
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] vals = new int[20001];
            int idx;
            for(int i = 0; i < numbers.Length; i++)
            {
                idx = numbers[i];
                if (idx != 0) idx += 1000;
                vals[idx] = i + 1;
            }

            int val; 
            for(int i =0; i < numbers.Length; i++)
            {
                val = numbers[i];
                idx = target - val;
                if (idx != 0) idx += 1000;
                if (vals[idx] != 0)
                    return new int[] { i + 1, vals[idx] };
            }

            return new int[] { 0, 0 };
        }
    }
}
