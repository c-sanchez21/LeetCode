using System;

namespace SetMismatch
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3658/
        static void Main(string[] args)
        {
            int[][] inputs = new int[][] { new int[] { 1, 2, 2, 4 }, new int[] { 1, 1 } };
            int[] output;
            foreach(int[] input in inputs)
            {
                output = FindErrorNums(input);
                Console.WriteLine("[{0},{1}]", output[0], output[1]);
            }
        }

        public static int[] FindErrorNums(int[] nums)
        {
            int[] copy = new int[nums.Length];
            int duplicate = 0, missing = 0, idx;
            foreach (int i in nums)
            {
                idx = i - 1;
                if (copy[idx] == 0)
                    copy[idx] = i;
                else duplicate = i;
            }
            for(int i = 0; i < copy.Length; i++)
            {
                if(copy[i] == 0)
                {
                    missing = (i + 1);
                    break;
                }
            }
            
            return new int[] { duplicate,missing };
        }
    }
}
