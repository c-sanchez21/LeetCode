using System;
using System.Collections.Generic;

namespace _560._Subarray_Sum_Equals_K
{
    class Program
    {
        //https://leetcode.com/problems/subarray-sum-equals-k/
        //Given an array of integers nums and an integer k,
        //return the total number of continuous subarrays whose sum equals to k.
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine( SubarraySum(new int[] { 1, 1, 1 }, 2));
            Console.WriteLine(SubarraySum(new int[] { 1, 2, 3 },3));
        }

        public static int SubarraySum(int[] nums, int k)
        {
            //Map for keeping track of running sums
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1); //Add 0 as default, i.e sum-k = 0 or Sum = k
            int sum = 0;
            int count = 0;

            //Iterate over all the numbers 
            for(int i = 0; i < nums.Length; i++)
            {
                sum += nums[i]; //Keep track of the sum
                if (map.ContainsKey(sum - k))
                    count += map[sum-k]; //Count the numbers of times we can add up to k

                //Add sum to the hashmap
                if (!map.ContainsKey(sum))
                    map.Add(sum, 0);
                map[sum]++;
            }
            return count; //Return count
        }
    }
}
