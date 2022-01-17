using System;
using System.Collections.Generic;

namespace _290._Word_Pattern
{
    class Program
    {
        //https://leetcode.com/problems/word-pattern/solution/
        static void Main(string[] args)
        {
            //Example Cases
            Console.WriteLine(WordPattern("abba", "dog cat cat dog"));
            Console.WriteLine(WordPattern("abba", "dog cat cat fish"));
            Console.WriteLine(WordPattern("aaaa", "dog cat cat dog"));
            Console.WriteLine(WordPattern("abba", "dog dog dog dog"));
        }

        public static bool WordPattern(string pattern, string str)
        {
            //Check for null or empty
            if (String.IsNullOrEmpty(pattern) && string.IsNullOrEmpty(str))
                return true; //Both Empty return true;
            else if (String.IsNullOrEmpty(pattern)) return false;
            else if (String.IsNullOrEmpty(str)) return false;

            //Check counts for consistency
            string[] words = str.Split(' ');
            if (pattern.Length != words.Length) return false;

            Dictionary<char, string> map = new Dictionary<char, string>();//Char to Word Map
            HashSet<string> usedWords = new HashSet<string>();//Track words that have been used
            char c; string word;

            //Check if the Pattern matches Word Pattern
            for (int i= 0; i < pattern.Length; i++)
            {
                c = pattern[i];
                word = words[i];
                if (!map.ContainsKey(c))
                {
                    //Word already used;
                    if (usedWords.Contains(word))
                        return false;

                    //Map new word
                    map.Add(c, word);
                    usedWords.Add(word);
                }
                else if (map[c].CompareTo(word) != 0) return false;
            }

            //Return true
            return true;

        }
    }
}
