using System;
using System.Collections.Generic;

namespace _532._K_diff_Pairs_in_an_Array
{
    class Program
    {
        //https://leetcode.com/problems/k-diff-pairs-in-an-array/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(FindPairs(new int[] { 3, 1, 4, 1, 5 }, 2));
            Console.WriteLine(FindPairs(new int[] { 1, 2, 3, 4, 5 }, 1));
            Console.WriteLine(FindPairs(new int[] { 1, 3, 1, 5, 4, 1}, 0));
            Console.WriteLine(FindPairs(new int[] { 1, 2, 4, 4, 3, 3, 0, 9, 2, 3}, 3)); //2
            Console.WriteLine(FindPairs(new int[] { 0, 0, 0, 0, 1, 1, 1, }, 0));
        }

        public static int FindPairs(int[] nums, int k)
        {
            //Check invalid input
            if (nums == null || nums.Length == 0) return 0;

            //Get the counts of all available numbers and store in hashmap
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!counts.ContainsKey(nums[i]))
                    counts.Add(nums[i], 0);
                counts[nums[i]]++;
            }

            //Iterate thru all the numbers and find unique pairs
            int a, b;
            int pairs = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                a = nums[i];
                if (counts[a] == 0) continue;
                counts[a]--; //Avoid using twice
                
                //a-b = k, or b = a-k
                b = a - k;
                if (counts.ContainsKey(b) && counts[b] > 0)
                {
                    //1st Pair Unique Pair
                    pairs++;
                    counts[a] = 0; //Avoid using the same pair twice - Case K = 0;
                }

                //b-a = k, or b = k+a
                b = k + a;
                if (counts.ContainsKey(b) && counts[b] > 0)
                    pairs++;

                counts[a] = 0; //Pairs for a found already.
            }
            return pairs;
        }
    }
}
