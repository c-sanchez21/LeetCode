using System;
using System.Collections.Generic;

namespace _454._4Sum_II
{
    class Program
    {
        //https://leetcode.com/problems/4sum-ii/
        static void Main(string[] args)
        {
            //Example 1:
            Console.WriteLine(fourSumCount(
                new int[] { 1, 2 },
                new int[] { -2, -1 },
                new int[] { -1, 2 },
                new int[] { 0, 2 }));

            //Example 2:
            Console.WriteLine(fourSumCount(
                new int[] { 0 },
                new int[] { 0 },
                new int[] { 0 },
                new int[] { 0 }));
           

            //Example 3:
            Console.WriteLine(fourSumCount(
                new int[] { -1, -1 },
                new int[] { -1, 1 },
                new int[] { -1, 1 },
                new int[] { 1, -1 }));
        } 

        public static int fourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            //Check for invalid input 
            if (nums1 == null || nums2 == null || nums3 == null || nums4 == null) return 0;

            //To reduce runtime store the sum of last 2 arrays in a hashmap
            Dictionary<int,int> map = new Dictionary<int,int>();

            int sum = 0;
            for (int i =0; i < nums3.Length; i++)
            {
                for(int j = 0; j < nums4.Length; j++)
                {
                    sum = nums3[i] + nums4[j]; 
                    if (!map.ContainsKey(sum))
                        map.Add(sum, 0);
                    map[sum]++;//Inrecment Count
                }
            }

            int count = 0;
            //Iterate thru the arrays and find the tuples 
            //that add up to zero. 
            for (int i = 0; i < nums1.Length; i++)
            {
                for(int j = 0; j < nums2.Length; j++)
                {
                    sum = nums1[i] + nums2[j];
                    sum = sum * -1;
                    if (map.ContainsKey(sum))
                        count += map[sum];
                }
            }

            return count;
        }
    }
}
