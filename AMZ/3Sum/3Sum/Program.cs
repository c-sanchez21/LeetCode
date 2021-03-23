using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2966/
        //https://leetcode.com/problems/3sum/
        static void Main(string[] args)
        {
            int[][] inputs = new int[][] //Array of arrays
                {new int[] {-1, 0, 1, 2, -1, -4}, new int[]{}, new int[] {0 }, new int[]{0,0,0 },
                 new int[] {-1, -1, -4, -3,-2, 0, 2, 4, 5 } };
            IList<IList<int>> output;
            foreach(int[] input in inputs)
            {
                output = ThreeSum(input);
                //Print Output
                Console.Write("[ ");
                foreach (IList<int> arr in output)
                {
                    Console.Write("[{0},{1},{2}] ", arr[0], arr[1], arr[2]);
                }
                Console.WriteLine("]");
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();

            if (nums == null || nums.Length < 3)
                return results;

            Array.Sort(nums);

            int prev = -100001;
            int l, r, curVal, sum, lo, hi;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                curVal = nums[i];
                if (curVal == prev) //Skip repeated numbers
                    continue;
                if (curVal > 0) //Won't be able to add up to Zero so break
                    break;
                l = i + 1;
                r = nums.Length - 1;
                while (l < r)
                {
                    lo = nums[l];
                    hi = nums[r];
                    sum = curVal + lo + hi;
                    if (sum == 0) //If target found
                    {
                        results.Add(new List<int>(new int[] { curVal, lo, hi })) ;
                        l++;
                        r--;
                        while (l < r && nums[l] == nums[l - 1])
                            l++;
                    }
                    else if (sum < 0)
                        l++;
                    else r--;
                }
                prev = curVal;
            }
            return results;
        }
    }
}
