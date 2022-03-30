using System;

namespace _81._Search_in_Rotated_Sorted_Array_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Search(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0));
        }


        //O(n) - Linear Search
        public static bool Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] == target) return true;
            return false;
        }
    }
}
