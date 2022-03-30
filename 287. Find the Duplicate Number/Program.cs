using System;

namespace _287._Find_the_Duplicate_Number
{
    class Program
    {
        //https://leetcode.com/problems/find-the-duplicate-number/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));
            Console.WriteLine(FindDuplicate(new int[] { 3, 1, 3, 4, 2 }));
        }

        public static int FindDuplicate(int[] nums)
        {
            //Find the largest number
            int maxNum = 0;
            for (int i = 0; i < nums.Length; i++)
                maxNum = Math.Max(maxNum, nums[i]);

            //Find most significant bit of the largest number
            int maxBit = 0;
            while(maxNum > 0)
            {
                maxBit++;
                maxNum = maxNum >> 1; // = maxNum/2;
            }

            int dup = 0;
            for(int bit = 0; bit < maxBit; bit++) //Iterate thru all bits
            {
                int mask = (1 << bit); //Set bit mask
                int baseCount = 0, numsCount = 0;
                for(int i =0; i < nums.Length; i++)
                {
                    if ((i & mask) > 0)
                        baseCount++;
                    if ((nums[i] & mask) > 0)
                        numsCount++;
                }
                if (numsCount > baseCount)
                    dup |= mask;
            }
            return dup;
        }
    }
}
