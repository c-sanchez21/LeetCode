using System;
using System.Collections.Generic;

namespace Sort_Array_By_Parity_II
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3990/
        static void Main(string[] args)
        {
            int[] ans = SortArrayByParityII(new int[] { 4, 2, 5, 7 });
            for (int i = 0; i < ans.Length; i++)
                Console.Write("{0} ", ans[i]);
        }

        public static int[] SortArrayByParityII(int[] nums)
        {
            //Initialize stack to hold to sort numbers
            Stack<int> even = new Stack<int>();
            Stack<int> odd = new Stack<int>();

            int numLength = nums.Length;

            //Sort Array
            for (int i = 0; i < numLength; i++)
                if (nums[i] % 2 == 0)
                    even.Push(nums[i]);
                else odd.Push(nums[i]);

            //Rebuild Array
            for (int i = 0; i < numLength; i++)
                if (i % 2 == 0)
                    nums[i] = even.Pop();
                else nums[i] = odd.Pop();

            return nums;


                

        }
    }
}
