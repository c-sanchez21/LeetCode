using System;
using System.Collections.Generic;

namespace DecompressRunLengthEncodedList
{
    //Problem: https://leetcode.com/problems/decompress-run-length-encoded-list/
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in DecompressRLElist(new int[] { 1, 2, 3, 4 }))
                Console.Write($" {i} ");
        }

        public static int[] DecompressRLElist(int[] nums)
        {
            List<int> results = new List<int>();
            for(int i = 0; i < nums.Length-1; i += 2)
            {
                for (int j = 0; j < nums[i]; j++)
                    results.Add(nums[i + 1]);
            }
            return results.ToArray();
        }
    }
}
