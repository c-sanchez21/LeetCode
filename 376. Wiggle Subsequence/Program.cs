using System;

namespace _376._Wiggle_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 }));
        }

        public static int WiggleMaxLength(int[] nums)
        {
            if (nums == null) return 0;
            int n = nums.Length;
            if (n < 2) return n;
            int[] up = new int[n];
            int[] down = new int[n];
            up[0] = down[0] = 1;
            for(int i =1; i < n; i++)
            {
                //Up
                if (nums[i - 1] < nums[i])
                {
                    up[i] = down[i - 1] + 1;
                    down[i] = down[i - 1];
                }
                //Down
                else if(nums[i - 1] > nums[i])
                {
                    down[i] = up[i - 1] + 1;
                    up[i] = up[i - 1];
                }
                else //Equal
                {
                    up[i] = up[i - 1];
                    down[i] = down[i - 1];
                }
            }
            return Math.Max(up[n-1], down[n-1]);
        }

    }
}
