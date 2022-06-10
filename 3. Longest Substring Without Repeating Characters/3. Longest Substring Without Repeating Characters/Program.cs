using System;
using System.Collections.Generic;

namespace _3._Longest_Substring_Without_Repeating_Characters
{
    //https://leetcode.com/problems/longest-substring-without-repeating-characters/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));//abc
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));//b
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));//wke
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return 1;
            int l, r;
            l = r = 0;
            int max = 0;
            HashSet<char> set = new HashSet<char>();
            char c;
            while (r < s.Length)
            {
                c = s[r];
                while (set.Contains(c))
                    set.Remove(s[l++]);
                set.Add(c);
                max = Math.Max(max, (r - l) + 1);
                r++;
            }
            return max;

        }
    }
}
