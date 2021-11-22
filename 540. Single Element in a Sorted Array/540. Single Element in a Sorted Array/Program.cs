using System;

namespace _540._Single_Element_in_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 2, 2 }));
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3 }));
            Console.WriteLine(SingleNonDuplicate(new int[] { 2, 2, 3 }));
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 2, 2, 3, 3}));
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 1, 2, 2, 3 }));
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }));
            Console.WriteLine(SingleNonDuplicate(new int[] { 3, 3, 7, 7, 10, 11, 11 }));
        }

        //O(log n) Solution - Divide & Conquer - Binary Search
        public static int SingleNonDuplicate2(int[] nums)
        {
            return SingleNonDuplicate(nums, 0, nums.Length - 1);
        }

        public static int SingleNonDuplicate(int[] nums, int l, int r)
        {
            //TODO: Implement
            return 0;
        }



        //O(n) Solution
        public static int SingleNonDuplicate(int[] nums)
        {
            int max = nums.Length;
            for (int i = 1; i < max-1; i += 2)
            {
                if(nums[i] != nums[i-1]) //Not equal left
                {
                    if (i == nums.Length - 1 || nums[i] != nums[i + 1]) //And not equal right
                        return nums[i]; //Return current
                    else return nums[i - 1]; //Return left
                }
            }
            return nums[max - 1];//Return last number
        }
    }
}
