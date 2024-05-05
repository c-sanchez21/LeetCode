using System;

namespace _16._3Sum_Closest
{
    class Program
    {
        //https://leetcode.com/problems/3sum-closest/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(ThreeSumClosest(new int[] { -1, 2, 1, -1 }, 1));
            Console.WriteLine(ThreeSumClosest(new int[] { 0, 0, 0 }, 1));
        }

        /// <summary>
        /// Given an integer array nums of length n and an integer target,
        /// find three integers in nums such that the sum is closest to target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>Returns the sum of the three integers</returns>
        public static int ThreeSumClosest(int[] nums, int target)
        {
            //Invalid input
            if (nums == null || nums.Length < 3) return 0;

            //Get first three numbers as starting point
            int closest = nums[0] + nums[1] + nums[2];

            //No need to evaluate if only 3 numbers
            if (nums.Length == 3) return closest; 

            Array.Sort(nums); //Sort numbers

            int prev = -100001; //Out of range value denoting null;

            //Iterate thru each number and utilize two pointers - left and right
            int l, r, curVal, sum, lo, hi;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                curVal = nums[i];

                //Skip repeated values
                if (curVal == prev)
                    continue;

                l = i + 1; //Left side 
                r = nums.Length - 1; //Right side

                //While left is less than right
                while (l < r)
                {
                    lo = nums[l];
                    hi = nums[r];
                    sum = curVal + lo + hi;

                    if (sum == target)
                        return sum;
                    else
                    {
                        //Update closes if closer
                        closest = Math.Abs(target - closest) < Math.Abs(target - sum) ?
                            closest : sum;
                    }
                    //Move either the left side or right side accordingly 
                    if (sum < target)
                        l++;
                    else r--;
                }

                prev = curVal;
            }
            return closest;
        }
    }
}
