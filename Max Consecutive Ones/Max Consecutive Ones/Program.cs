using System;

namespace Max_Consecutive_Ones
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3982/
        static void Main(string[] args)
        {
            Console.WriteLine(FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 }));//3
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            //Base Case
            if (nums == null || nums.Length == 0) return 0;

            int count = 0; //Current count of 1's
            int max = 0; //Max Count of 1's
            
            //Iterate over array O(N)
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) //Count consecutive 1's
                    count++;
                else //If 0 - restart count and update max
                {
                    max = Math.Max(max, count); //Take greater of two values
                    count = 0;
                }
            }
            max = Math.Max(max, count); //Take greater of two values
            return max;
        }
    }
}
