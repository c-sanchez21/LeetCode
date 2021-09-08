using System;

namespace Array_Nesting
{
    //https://leetcode.com/problems/array-nesting/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ArrayNesting(new int[] { 5, 4, 0, 3, 1, 6, 2 }));
            Console.WriteLine(ArrayNesting(new int[] { 0, 1, 2 }));
        }

        public static int ArrayNesting(int[] nums)
        {
            int max = nums.Length; 
            bool[] visited = new bool[max];
            int ans = 0;
            for (int i = 0; i < max; i++)
            {
                if (!visited[i])
                {
                    int start = nums[i], count = 0;
                    do
                    {
                        start = nums[start];
                        count++;
                        visited[start] = true;
                    }
                    while (start != nums[i]);
                    ans = Math.Max(ans, count);
                }
            }
            return ans;
        }
    }
}
