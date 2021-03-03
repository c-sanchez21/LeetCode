using System;

namespace MissingNumber
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3659/
        static void Main(string[] args)
        {
            int[][] inputs = new int[][]
            { new int[] { 3, 0, 1 }, new int[]{0,1}, new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, new int[] {0}};
            foreach (int[] input in inputs)
                Console.WriteLine("Missing Number: {0}", MissingNumber(input));
        }
        public static int MissingNumber(int[] nums)
        {
            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];
            //Gauss formula
            int n = nums.Length;
            long seriesSum = (n * (n + 1)) / 2;
            return (int)(seriesSum - sum);

        }
    }
}
