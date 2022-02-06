using System;

namespace _1512._Number_of_Good_Pairs
{
    class Program
    {
        //https://leetcode.com/problems/number-of-good-pairs/
        static void Main(string[] args)
        {
            //Example 1: 
            int pairs = NumIdenticalPairs(new int[] { 1, 2, 3, 1, 1, 3 });
            Console.WriteLine(pairs);
        }

        //Returns numbers of pairs where nums[i] == nums[j] & i < j
        public static int NumIdenticalPairs(int[] nums)
        {
            int pairs = 0;
            for (int i = 0; i < nums.Length - 1; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] == nums[j])
                        pairs++;
            return pairs;
        }
    }
}
