using System;
using System.Collections.Generic;

namespace _525._Contiguous_Array
{
    class Program
    {
        //https://leetcode.com/problems/contiguous-array/
        static void Main(string[] args)
        {
            //Exaample 1: = 2
            Console.WriteLine(FindMaxLength(new int[] { 0, 1 }));

            //Example 2: = 2
            Console.WriteLine(FindMaxLength(new int[] { 0, 1, 0 }));

            //Example 3: = 4
            Console.WriteLine(FindMaxLength(new int[] { 1,1,1, 0, 1, 0,1,1,1,1}));

            //Example 4: = 4 
            Console.WriteLine(FindMaxLength(new int[] { 0, 1, 1, 0, 1, 1, 1, 0 }));

        }

        //Find Max Length - using Hashmap
        public static int FindMaxLength(int[] nums)
        {
            //Check invalid input
            if (nums == null || nums.Length == 0) return 0;

            //Keep track of zeroes and one's count
            Dictionary<int, int> counts = new Dictionary<int, int>();//Counts & Index
            int count = 0; 

            counts.Add(count, -1);//Initial Counts
            int max = 0; //Max Length; 

            for(int i =0; i < nums.Length;i++)
            {
                //If 1 subtract one else Add one for zeros
                count += nums[i] == 1 ? 1 : -1;

                //Encountering the same count twice implies we 
                //have an equal amount of zeroes and ones
                if (counts.ContainsKey(count))
                    max = Math.Max(max, i - (counts[count]));
                else counts.Add(count, i);
            }

            return max;
        }

        //Find Max Length - Fails for test case: { 0, 1, 1, 0, 1, 1, 1, 0 }
        public static int FindMaxLength1(int[] nums)
        {
            //Check invalid input
            if (nums == null || nums.Length == 0) return 0;

            //Count the Number of Zeroes and Ones
            int oneCount = 0;
            int zCount = 0;
            for(int i =0; i < nums.Length; i++)
                if (nums[i] == 1) oneCount++;
                else zCount++;

            //Check edge case
            if (oneCount == 0 || zCount == 0) return 0;

            //Find Max Lenght by gradually reducing
            //from left and right as needed.
            int l, r; 
            l = 0; r = nums.Length - 1;//Left & Right Index
            while (oneCount != zCount && l < r)
            {
                //Remove One
                if(oneCount > zCount)
                {
                    if (nums[l] == 1)
                    {
                        l++;
                        oneCount--;
                    }
                    else if(nums[r] == 1)
                    {
                        r--;
                        oneCount--;
                    }
                    else //Fails for above test case -
                         //possibly using Recursion Math.Max trying from both sides
                    {
                        l++;
                        zCount--;
                    }
                }

                //Remove Zero
                if (zCount > oneCount)
                {
                    if (nums[l] == 0)
                    {
                        l++;
                        zCount--;
                    }
                    else if (nums[r] == 0)
                    {
                        r--;
                        zCount--;
                    }
                    else //Fails for above test case -
                         //possibly using Recursion Math.Max trying from both sides
                    {
                        l++;
                        oneCount--;
                    }
                }
            }

            return oneCount + zCount;
        }
    }
}
