using System;

namespace _1413._Minimum_Value_to_Get_Positive_Step_by_Step_Sum
{
    class Program
    {
        //https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
        static void Main(string[] args)
        {
            Console.WriteLine(MinStartValue(new int[] { -3, 2, -3, 4, 2 }));
            Console.WriteLine(MinStartValue(new int[] {1,2 }));
            Console.WriteLine(MinStartValue(new int[] {1,-2,-3}));
        }

        public static int MinStartValue(int[] nums)
        {
            int min = int.MaxValue;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < min)
                    min = sum;
            }
            int ans = min < 1 ? (min * -1) + 1 : 1;
            return ans; 
        }
    }
}
