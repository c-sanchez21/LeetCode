using System;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        //https://leetcode.com/problems/product-of-array-except-self/
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/499/

        static void Main(string[] args)
        {
            int[] ans = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            foreach (int a in ans)
                Console.Write("{0} ",a);
        }

        //Without Division and O(1) space complexity
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] ans = new int[nums.Length];

            ans[0] = 1;
            //Multiply numbers from the left
            for (int i = 1; i < nums.Length; i++)
                ans[i] = nums[i - 1] * ans[i - 1];

            //Multiply numbers from the right
            int r = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                ans[i] = ans[i] * r;
                r *= nums[i];
            }

            return ans;
        }
    }
}
