using System;
using System.Net.Http.Headers;

namespace _45._Jump_Game_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jump(new int[] { 2, 3, 1, 2, 4 }));
            Console.WriteLine(Jump(new int[] { 2, 3, 0, 1, 4 }));
        }

        static int[] cache;
        public static int Jump(int[] nums)
        {
            cache = new int[nums.Length];
            return Jump(nums, 0);
        }

        public static int Jump(int[] nums, int idx)
        {
            if(idx == nums.Length - 1) return 0;
            if (idx >= nums.Length) return -1;
            if (cache[idx] > 0) return cache[idx];
            int jumps = nums[idx];
            int min = int.MaxValue;
            int cur;
            for(int i=1 ; i<=jumps; i++)
            {
                cur = Jump(nums, idx + i);
                if(cur > -1) 
                    min = Math.Min(cur, min);
            }
            cache[idx] = min + 1;
            return cache[idx];
        }
    }


}
