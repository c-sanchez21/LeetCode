using System;

namespace _704._Binary_Search
{
    //https://leetcode.com/problems/binary-search/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9));
            Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));
        }

        public static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            return Search(nums, target,nums.Length/2, 0, nums.Length - 1);
        }

        public static int Search(int[] nums, int target,int idx, int l, int r)
        {
            if (nums[idx] == target) return idx;
            if (l == r) return -1;
            if (nums[idx] < target)
                l = idx + 1;
            else r = idx - 1;
            return Search(nums, target, (l + r) / 2, l, r);
        }
    }
}
