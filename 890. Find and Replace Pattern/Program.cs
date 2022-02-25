using System;
using System.Collections.Generic;

namespace _890._Find_and_Replace_Pattern
{
    class Program
    {
        //https://leetcode.com/problems/find-and-replace-pattern/
        static void Main(string[] args)
        {
            //Example 1
            IList<string> results = FindAndReplacePattern(new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" }, "abb");
            PrintResults(results);
        }

        static void PrintResults(IEnumerable<string> list)
        {
            Console.WriteLine("[{0}]", String.Join(" ", list));
        }

        public static IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            List<string> results = new List<string>();

            //Iterate thru all the words in the list
            foreach (string word in words)
            {
                
                Dictionary<char, char> map = new Dictionary<char, char>();
                HashSet<char> used = new HashSet<char>();
                int i;
                
                //Map each in the word to a letter in the pattern
                for (i = 0; i < word.Length; i++)
                {
                    //New letter
                    if (!map.ContainsKey(word[i]))
                    {
                        if (used.Contains(pattern[i]))
                            break;//Letter in the pattern was already used 
                        map.Add(word[i], pattern[i]);
                        used.Add(pattern[i]);
                    }
                    else if (map[word[i]] != pattern[i])
                        break; //Pattern mismatch
                }
                //If Pattern Match - Add word
                if (i == word.Length)
                    results.Add(word);
            }
            return results;
        }
    }
}
