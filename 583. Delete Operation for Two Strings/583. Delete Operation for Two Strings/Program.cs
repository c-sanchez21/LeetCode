using System;

namespace _583._Delete_Operation_for_Two_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinDistance("sea", "eat"));
            Console.WriteLine(MinDistance("leetcode", "etco"));
        }

        static int[,] cache;
        public static int MinDistance(string word1, string word2)
        {
            cache = new int[word1.Length + 1, word2.Length + 1];
            return word1.Length + word2.Length - (2 * LCS(word1, word2, word1.Length, word2.Length));
        }

        public static int LCS(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (cache[m, n] > 0) return cache[m, n];
            if (s1[m - 1] == s2[n - 1])
                cache[m, n] = 1 + LCS(s1, s2, m - 1, n - 1);
            else
                cache[m, n] = Math.Max(LCS(s1, s2, m, n - 1), LCS(s1, s2, m - 1, n));
            return cache[m, n];
        }
    }
}
