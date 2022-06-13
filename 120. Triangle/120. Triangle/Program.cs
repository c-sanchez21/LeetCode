using System;
using System.Collections.Generic;

namespace _120._Triangle
{
    internal class Program
    {
        //https://leetcode.com/problems/triangle/
        static void Main(string[] args)
        {
            IList<IList<int>> list1 = new List<IList<int>>();
            list1.Add(new List<int>(new int[] { 2 }));
            list1.Add(new List<int>(new int[] { 3,4 }));
            list1.Add(new List<int>(new int[] { 6, 5, 7, }));
            list1.Add(new List<int>(new int[] { 4, 1, 8, 3 }));
            Console.WriteLine(MinimumTotal(list1)); //11
        }

        static int[] cache;
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0) return 0;
            List<int> nums = new List<int>();
            foreach (IList<int> list in triangle)
                foreach (int i in list)
                    nums.Add(i);
            
            if(nums.Count == 0) return 0;
            if (nums.Count == 1) return nums[0];

            //Reset Cache
            cache = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
                cache[i] = int.MinValue;

            return MinMax(nums.ToArray(), 0, 1);
        }
        public static int MinMax(int[] nums, int idx, int lvl)
        {
            if (idx >= nums.Length) return 0;
            if (cache[idx] != int.MinValue) return cache[idx];
            cache[idx] =  nums[idx] + Math.Min(MinMax(nums, idx + lvl, lvl + 1), MinMax(nums, idx + lvl + 1, lvl + 1));
            return cache[idx];
        }
    }
}
