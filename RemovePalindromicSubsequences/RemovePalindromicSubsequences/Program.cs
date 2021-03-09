using System;

namespace RemovePalindromicSubsequences
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3665/
        //https://leetcode.com/problems/remove-palindromic-subsequences/
        static void Main(string[] args)
        {
            string[] inputs = new string[] { "ababa", "abb", "baabb", "" };
            foreach (string input in inputs)
                Console.WriteLine("{0}={1}", input, RemovePalindromeSub(input));
        }

        public static int RemovePalindromeSub(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            int l = 0;
            int r = s.Length - 1;
            while (l < r)
                if (s[l++] != s[r--]) return 2;//If not palindrome
            return 1;
        }
    }
}
