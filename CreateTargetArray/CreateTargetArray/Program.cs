using System;
using System.Collections.Generic;

namespace CreateTargetArray
{
    //Problem: https://leetcode.com/problems/create-target-array-in-the-given-order/
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 0 };
            int[] index = { 0, 1, 2, 3, 0 };
            int[] res = CreateTargetArray(nums, index);
            foreach (int i in res)
                Console.Write($" {i} ");
        }

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            List<int> target = new List<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                target.Insert(index[i], nums[i]);
            }
            return target.ToArray();
        }
    }
}
