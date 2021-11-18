using System;
using System.Collections.Generic;

namespace _448._Find_All_Numbers_Disappeared_in_an_Array
{
    class Program
    {
        //https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        static void Main(string[] args)
        {
            Print(FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }));
            Print(FindDisappearedNumbers(new int[] { 1,1 }));
            Print(FindDisappearedNumbers(new int[] { 1, 1, 1, 1, 2, 2, 3, 1 }));
        }

        public static void Print(IList<int> nums)
        {
            Console.Write("[ ");
            foreach (int i in nums)
                Console.Write("{0} ", i);
            Console.Write("]");
            Console.WriteLine();
        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> results = new List<int>();
            int idx, val;
            for (int i = 0; i < nums.Length; i++)
            {
                idx = Math.Abs(nums[i]) - 1;
                val = nums[idx];
                //Negate value
                nums[idx] = Math.Abs(val) * -1;
            }
            
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] > 0)
                    results.Add(i + 1);
            return results;
        }
    }
}
