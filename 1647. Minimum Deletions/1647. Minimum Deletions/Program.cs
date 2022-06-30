using System;
using System.Collections.Generic;

namespace _1647._Minimum_Deletions
{
    internal class Program
    {
        //https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/
        static void Main(string[] args)
        {
            Console.WriteLine(MinDeletions("aab"));
            Console.WriteLine(MinDeletions("aaabbbcc"));
            Console.WriteLine(MinDeletions("ceabaacb"));
        }

        public static int MinDeletions(string s)
        {
            int[] arr = new int[26];
            int idx;
            for (int i = 0; i < s.Length; i++)
            {
                idx = s[i] - 'a';
                arr[idx]++;
            }
            HashSet<int> set = new HashSet<int>();
            int count;
            int steps = 0;
            for(int i =0;i < arr.Length;i++)
            {
                count = arr[i];
                if (!set.Contains(count))
                    set.Add(count);
                else
                {
                    while (set.Contains(count) && count > 0)
                    {
                        count--;
                        steps++;
                    }
                    if (count > 0)
                        set.Add(count);
                }
            }
            return steps;
        }
    }
}
