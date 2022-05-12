using System;
using System.Collections.Generic;

namespace _47._Permutations_II
{
    //https://leetcode.com/problems/permutations-ii/
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> ans = PermuteUnique(new int[] { 1, 1, 2 });
            foreach (IList<int> list in ans)
            {
                Console.WriteLine(string.Join(' ', list));
            }
        }

        static public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();

            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!counter.ContainsKey(num))
                    counter.Add(num, 0);
                counter[num]++;
            }

            List<int> comb = new List<int>();
            PermuteUnique(comb, nums.Length, counter, results);
            return results;
        }

        public static void PermuteUnique(List<int> comb, int n, Dictionary<int, int> counter, List<IList<int>> results)
        {
            if(comb.Count == n)
            {
                results.Add(new List<int>(comb));
                return;
            }

            int num, count;
            foreach(KeyValuePair<int,int> kvp in counter)
            {
                num = kvp.Key;
                count = kvp.Value;
                if (count == 0)
                    continue;
                comb.Add(num);
                counter[num]--;
                PermuteUnique(comb, n, counter, results);
                comb.RemoveAt(comb.Count - 1);
                counter[num]++;
            }
        }
    }
}
