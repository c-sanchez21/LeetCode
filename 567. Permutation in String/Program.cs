using System;
using System.Collections.Generic;
using System.Linq;

namespace _567._Permutation_in_String
{
    class Program
    {
        //https://leetcode.com/problems/permutation-in-string/
        //Find if s2 contains a permutation of s1

        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
            Console.WriteLine(CheckInclusion("ab", "eidboaoo"));
            Console.WriteLine(CheckInclusion("", "aaaaaaaaaa"));
            Console.WriteLine(CheckInclusion("a", "aaaaaa"));
            Console.WriteLine(CheckInclusion("abb", "abab"));
            Console.WriteLine(CheckInclusion("abb", "aba"));
            Console.WriteLine(CheckInclusion("abc", "cab"));

        }

        //Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        public static bool CheckInclusion(string s1, string s2)
        {
            //Check invalid input
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2)) return false;
            if (s1.Length > s2.Length) return false;

            //Case of only 1 letter 
            if (s1.Length == 1) return s2.Contains(s1);

            //Hashmap to hold letters from s1
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach(char c in s1)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 0);
                map[c]++;
            }

            int count = 0; //Letters Found
            Dictionary<char, int> counts = new Dictionary<char, int>();
            char ch;
            int s1Length = s1.Length;
            for (int i = 0; i < s2.Length; i++)
            {
                ch = s2[i];
                if (map.ContainsKey(ch))
                {
                    if (!counts.ContainsKey(ch))
                        counts.Add(ch, 0);
                    counts[ch]++;
                    count++;
                    if(count == s1.Length)
                    {
                        if (map.Count == counts.Count && !map.Except(counts).Any())
                            return true;
                        else //Remove last letter on the left
                        {
                            char chLeft = s2[i - (s1Length - 1)];
                            counts[chLeft]--;
                            count--;
                        }
                    }
                }
                else
                {
                    count = 0;
                    counts.Clear();
                }
            }
            return false;
        }
    }
}
