using System;
using System.Collections.Generic;
using System.Text;

namespace _1048._Longest_String_Chain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestStrChain(new string[]
                {"a","b","ba","bca","bda","bdca"}));
        }

        static Dictionary<string, int> cache;
        public static int LongestStrChain(string[] words)
        {
            cache = new Dictionary<string, int>();
            HashSet<string> curSet = new HashSet<string>();
            foreach (string word in words)
                curSet.Add(word);
            int max  = 0;
            foreach (string word in words)
                max = Math.Max(max, DFS(curSet, word));
            return max;
        }

        public static int DFS(HashSet<string> words, string curWord)
        {
            if (cache.ContainsKey(curWord)) return cache[curWord];

            int maxLength = 1;
            StringBuilder sb = new StringBuilder(curWord);
            for(int i = 0; i < curWord.Length; i++)
            {
                sb.Remove(i, 1); //Remove each letter
                string newWord = sb.ToString();

                if(words.Contains(newWord))
                {
                    int curLength = 1 + DFS(words, newWord);
                    maxLength = Math.Max(maxLength, curLength);
                }
                sb.Insert(i, curWord[i]);
            }
            cache.Add(curWord, maxLength);
            return maxLength;
        }
    }
}
