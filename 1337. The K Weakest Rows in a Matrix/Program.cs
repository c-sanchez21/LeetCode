using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _1337._The_K_Weakest_Rows_in_a_Matrix
{
    class Program
    {
        //https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int j = 0; j < mat.Length; j++)
                for (int i = 0; i < mat[j].Length; i++)
                {
                    if (!map.ContainsKey(j))
                        map.Add(j, 0);
                    if (mat[j][i] == 1)
                        map[j]++;
                }
            List<KeyValuePair<int, int>> list = map.ToList();
            list.Sort(
                delegate (KeyValuePair<int, int> x, KeyValuePair<int, int> y)
                {
                    if (x.Value != y.Value) return x.Value.CompareTo(y.Value);
                    return x.Key.CompareTo(y.Key);
                }
                );
            List<int> results = new List<int>();
            for (int i = 0; i < k; i++)
                results.Add(list[i].Key);
            return results.ToArray();
        }
    }
}
