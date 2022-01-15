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

            //Iterate thru nums - find longest set possible
            for (int i = 0; i < max; i++)
            {
                if (!visited[i]) //Skip sets are visited
                {
                    int start = nums[i], count = 0;
                    do
                    {
                        start = nums[start];
                        count++;
                        visited[start] = true;
                    }
                    while (start != nums[i]); //Stop at first cycle 

                    //Keep track of the largest possible set
                    ans = Math.Max(ans, count);
                }
            }
            return ans;
        }
    }
}
