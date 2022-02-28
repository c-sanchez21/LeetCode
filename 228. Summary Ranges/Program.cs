using System;
using System.Collections.Generic;

namespace _228._Summary_Ranges
{
    //https://leetcode.com/problems/summary-ranges/submissions/
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1
            Console.WriteLine(String.Join(' ', SummaryRanges(new int[] { 0, 1, 2, 4, 5, 7 })));

            //Example 2
            Console.WriteLine(String.Join(' ', SummaryRanges(new int[] { 0, 2, 3, 4, 6, 8,9 })));
        }

        public static List<String> SummaryRanges(int[] nums)
        {
            List<string> results = new List<string>();

            //Check invalid results
            if (nums == null || nums.Length == 0) return results;

            int j;
            for(int i = 0; i < nums.Length; i++)
            {
                j = i;
                //While numbers are in ascending order and differ by 1
                while (j + 1 < nums.Length && nums[j] + 1 == nums[j + 1])
                    j++;

                if (i == j)
                    results.Add(nums[i].ToString()); //Add single number
                else results.Add(nums[i] + "->" + nums[j]); //Add Range
                i = j;
            }
            return results;
        }
    }
}
