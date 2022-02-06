using System;

namespace _80._Remove_Duplicates_from_Sorted_Array_II
{
    class Program
    {
        //https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(RemoveDuplicates(new int[] { 1, 1, 1, 2, 2, 3 })); //5
            Console.WriteLine(RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 })); //7
        }

        //Remove duplicates in place - keep at most 2
        public static int RemoveDuplicates(int[] nums)
        {
            //Base Case
            if (nums == null || nums.Length == 0) return 0;

            //Initialize Variables
            int prevElement = int.MinValue;
            int idx = 0;
            int count = 0;
            int k = 0;
            int i = 0;

            //Iterate thru the entire array
            while (i < nums.Length)
            {
                if(nums[i] == prevElement)
                {
                    if(count == 2) //Skip
                    {
                        i++;
                        continue;
                    }
                    else //Second Element found
                    {
                        nums[idx++] = nums[i];
                        k++;
                        count++;
                    }
                }
                else //New element found
                {
                    k++;
                    nums[idx++] = nums[i];
                    count = 1;
                }
                prevElement = nums[i];
                i++;
            }
            return k;
        }
    }
}
