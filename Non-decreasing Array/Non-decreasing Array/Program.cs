using System;

namespace Non_decreasing_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckPossibility(new int[] { 4, 2, 3 }));//True
            Console.WriteLine(CheckPossibility(new int[] { 4, 2, 1 }));//False
            Console.WriteLine(CheckPossibility(new int[] { 3, 4, 2, 3 }));//False
            Console.WriteLine(CheckPossibility(new int[] { 5, 7, 1, 8 }));//True

        }

        //Given an array nums with n integers,
        //your task is to check if it could become non-decreasing by modifying at most one element.
        public static bool CheckPossibility(int[] nums)
        {
            for(int i = 0; i < nums.Length-1; i++)
            {
                //Find the first anomaly
                if (nums[i + 1] - nums[i] < 0)
                {
                    //Anomaly found - Makes a copy of the array. (Yes, I know not optimal... :( )
                    int[] a1 = new int[nums.Length];
                    int[] a2 = new int[nums.Length];
                    Array.Copy(nums, a1, nums.Length);
                    Array.Copy(nums, a2, nums.Length);
                    
                    //Make the numbers the same - two choices. 
                    a1[i] = nums[i + 1]; //First possiblity nums[i] = nums[i+1]
                    a2[i + 1] = nums[i]; //Second possibilty nums[i+1] = nums[i]

                    //Check if either possibility will work. 
                    return CheckPossibility2(a1) || CheckPossibility2(a2);
                }
            }
            return true;
        }

        public static bool CheckPossibility2(int[] nums)
        {
            //Runs trough array and returns false when non-decreasing order is found. 
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - nums[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
