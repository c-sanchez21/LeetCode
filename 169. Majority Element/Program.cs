using System;

namespace _169._Majority_Element
{
    class Program
    {
        //https://leetcode.com/problems/majority-element/
        static void Main(string[] args)
        {
            //Example 
            Console.WriteLine(MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 }));
        }

        public static int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            //Since majority element appears more than n/2 times
            return nums[nums.Length / 2];
        }
    }
}
