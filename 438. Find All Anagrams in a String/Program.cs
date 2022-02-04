using System;
using System.Collections.Generic;
using System.Linq;

namespace _438._Find_All_Anagrams_in_a_String
{
    class Program
    {
        //https://leetcode.com/problems/find-all-anagrams-in-a-string/
        static void Main(string[] args)
        {
            //Example:
            IList<int> results1 = FindAnagrams("cbaebabacd", "abc");
            Console.Write("[");
            foreach (int i in results1)
                Console.Write("{0} ", i);
            Console.Write("]");
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            List<int> results = new List<int>();

            //Check for invalid inputs
            if (String.IsNullOrEmpty(s) || String.IsNullOrEmpty(p)) return results;
            if (s.Length < p.Length) return results;

            int[] pCount = new int[26];
            int[] sCount = new int[26];

            //Put p into an array
            foreach (char c in p)
                pCount[(int)c - 'a']++;

            //Use sliding window to find Anagrams
            int pLength = p.Length;
            for(int i = 0; i < s.Length; i++)
            { 
                //Add leter from the right
                sCount[(int)s[i] - 'a']++;

                //Remove letter from the left
                if(i >= pLength)
                    sCount[s[i-pLength] - 'a']--;

                //Compare the arrays
                if (sCount.SequenceEqual(pCount))
                    results.Add(i - pLength + 1);
            }

            return results;
        }

            //Sliding Window with Hashmaps - Exceeds Time Limit
            public static IList<int> FindAnagrams1(string s, string p)
        {
            //Put string p into a hashmap
            Dictionary<char, int> pCounts = new Dictionary<char, int>();
            foreach(char c in p)
            {
                if (!pCounts.ContainsKey(c))
                    pCounts.Add(c, 0);
                pCounts[c]++;
            }

            //Use a sliding window adding characters to the right and removing from the left. 
            Dictionary<char, int> sCounts = new Dictionary<char, int>();
            List<int> results = new List<int>();
            char ch;
            for (int i = 0; i < s.Length; i++)
            {
                //Add from the right
                ch = s[i];
                if (!sCounts.ContainsKey(ch))
                    sCounts.Add(ch, 0);
                sCounts[ch]++;

                //Remove from the left
                if (i >= p.Length)
                {
                    ch = s[i - p.Length];
                    sCounts[ch]--;
                    if (sCounts[ch] == 0) sCounts.Remove(ch);
                }

                //Check Dictionaries for equality -- Note: does not work with reference types 
                if(pCounts.Count == sCounts.Count && !pCounts.Except(sCounts).Any())
                        results.Add(i - p.Length +1);
            }
            return results;
        }
    }
}
