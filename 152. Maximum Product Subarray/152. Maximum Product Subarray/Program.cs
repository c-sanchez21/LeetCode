using System;

namespace _152._Maximum_Product_Subarray
{
    //https://leetcode.com/problems/maximum-product-subarray/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProduct(new int[] { 2, 3, -2, 4 }));
            Console.WriteLine(MaxProduct(new int[] { -2, 0, -1 }));
            Console.WriteLine(MaxProduct(new int[] { 0, 2 }));
            Console.WriteLine(MaxProduct(new int[] { -2, 3, -4 }));
        }

        public static int MaxProduct(int[] nums)
        {
            //Base Case
            if (nums == null || nums.Length == 0) return 0;

            int curMax = nums[0];//Current Max
            int curMin = nums[0];//Current Min
            int res = curMax;

            int cur, tempMax; 

            for(int i = 1; i < nums.Length; i++)
            {
                cur = nums[i];//Current Number
                
                //Store the max value
                tempMax = Math.Max(cur, Math.Max(curMax * cur, curMin * cur));

                //Store the min value
                curMin = Math.Min(cur, Math.Min(curMax * cur, curMin * cur));


                curMax = tempMax; //Set current max; 
                res = Math.Max(curMax, res); //Set Result to the greater of the two
            }

            return res; //Return Result
        }
    }
}
