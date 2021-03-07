using System;
using System.Collections.Generic;

namespace ShortEncodingofWords
{
    class Program
    {
        //https://leetcode.com/problems/short-encoding-of-words/solution/
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3662/
        static void Main(string[] args)
        {
            Console.WriteLine(MinimumLengthEncoding(new string[] { "time", "me", "bell" }));
            Console.WriteLine(MinimumLengthEncoding(new string[] { "t" }));
        }

        public static int MinimumLengthEncoding(string[] words)
        {
            //Put words into a Set
            HashSet<string> wordsHash = new HashSet<string>();
            foreach (string word in words)
                wordsHash.Add(word);

            //Remove words contained in other words
            foreach(string word in words)
            {
                for (int i = 1; i < word.Length; i++)
                    if (wordsHash.Contains(word.Substring(i)))
                        wordsHash.Remove(word.Substring(i));
            }

            //Add up remaining words. 
            int result = 0;
            foreach (string word in wordsHash)
                result += word.Length + 1;

            return result;
        }
    }
}
