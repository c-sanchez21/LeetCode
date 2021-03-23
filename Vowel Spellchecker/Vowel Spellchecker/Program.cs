using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Vowel_Spellchecker
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3681/
        static void Main(string[] args)
        {
            string[] wordlist = { "KiTe", "kite", "hare", "Hare" };
            string[] queries = { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" };
            
            
            //Ouput should be: ["kite","KiTe","KiTe","Hare","hare","","","KiTe","","KiTe"]
            foreach (string s in Spellchecker(wordlist, queries))
                Console.Write("{0} ", s);

            Console.WriteLine();


            //Second custom test
            string[] wordlist2 = { "yellow", "Yellow","YellOw" };
            string[] queries2 = { "YellOw", "yellow", "yollow", "yeellow", "yllw" };
            string[] results = Spellchecker(wordlist2, queries2);
            for (int i = 0; i < queries2.Length; i++)
                Console.WriteLine("'{0}' = '{1}' ",queries2[i], results[i] );
        }

        public static string[] Spellchecker(string[] wordlist, string[] queries)
        {
            //Hashset & Dictionary to store wordlist
            HashSet<string> wordSet = new HashSet<string>();
            Dictionary<string, string> wordDict = new Dictionary<string, string>();

            string upper, vowelWildcard; 
            foreach(string word in wordlist)
            {
                //Store all words in the hashset for possible exact match
                wordSet.Add(word);

                //Sote all words in the dictionary for case insenstive
                //And for possible vowel replacement
                upper = word.ToUpper();

                //Turn upper case with vowels turned into wildcards
                vowelWildcard = Regex.Replace(upper, "[AEIOU]", "*");

                //Store first word matches in the dictionary
                if (!wordDict.ContainsKey(upper))
                    wordDict.Add(upper, word);
                
                if(!wordDict.ContainsKey(vowelWildcard))
                    wordDict.Add(vowelWildcard, word);
            }

            //Process Queries
            List<string> results = new List<string>();
            foreach(string query in queries)
            {
                if (wordSet.Contains(query))
                    results.Add(query);
                else
                {
                    upper = query.ToUpper();
                    vowelWildcard = Regex.Replace(upper, "[AEIOU]", "*");
                    if (wordDict.ContainsKey(upper))
                        results.Add(wordDict[upper]);
                    else if (wordDict.ContainsKey(vowelWildcard))
                        results.Add(wordDict[vowelWildcard]);
                    else results.Add("");
                }
            }
            return results.ToArray();
        }
    }
}
