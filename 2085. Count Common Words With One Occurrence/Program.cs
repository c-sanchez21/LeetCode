using System;
using System.Collections.Generic;

namespace _2085._Count_Common_Words_With_One_Occurrence
{
    class Program
    {
        //https://leetcode.com/problems/count-common-words-with-one-occurrence/
        static void Main(string[] args)
        {
            //Example
            string[] words1 = new string[] { "leetcode", "is", "amazing", "as", "is" };
            string[] words2 = new string[] { "amazing", "leetcode", "is" };
            Console.WriteLine(CountWords(words1, words2));
        }

        public static int CountWords(string[] words1, string[] words2)
        {
            //Word Dictionary to keep track of word counts
            Dictionary<string, int> words1Map = new Dictionary<string, int>();
            Dictionary<string, int> words2Map = new Dictionary<string, int>();

            //Add the words to their respective dictionaries
            AddWords(words1, words1Map);
            AddWords(words2, words2Map);

            //Count the words that appear exactly once
            int count = 0;
            foreach(string word in words1)
            {
                if (words1Map.ContainsKey(word) && words1Map[word] == 1)
                    if (words2Map.ContainsKey(word) && words2Map[word] == 1)
                        count++;
            }
            return count;
        }

        //Helper method to add words to dictionary
        private static void AddWords(string[] words, Dictionary<string,int> map)
        {
            foreach(string word in words)
            {
                if(!map.ContainsKey(word))
                    map.Add(word, 0);
                map[word]++;
            }
        }
    }
}
