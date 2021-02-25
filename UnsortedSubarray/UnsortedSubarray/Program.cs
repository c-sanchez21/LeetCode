using System;

namespace UnsortedSubarray
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3651/
        static void Main(string[] args)
        {
            Console.WriteLine(FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 1 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 2, 3, 4, 1 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 1, 3, 4, 2 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 2, 1 }));
        }

        public static int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int idx1 = -1, idx2 = -1;

            //Find left boundary
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        idx1 = i;
                        i = nums.Length;
                        break;
                    }
                }
            }
            if (idx1 == -1) return 0; //Array already sorted. 

            //Find right boundary
            for(int i = nums.Length-1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] < nums[j])
                    {
                        idx2 = i;
                        i = 0;
                        break;
                    }
                }
            }
            return ((idx2 - idx1) + 1);
        }
    }
}
