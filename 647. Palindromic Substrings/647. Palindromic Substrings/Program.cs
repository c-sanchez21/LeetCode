using System;

namespace _647._Palindromic_Substrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSubstrings("abc"));
            Console.WriteLine(CountSubstrings("aaa"));
            Console.WriteLine(CountSubstrings("xzzx"));
        }

        public static int CountSubstrings(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            int n = s.Length;
            bool[,] cache = new bool[n, n];

            int res = 0; //Results

            //Single letters are palindromes
            for (int i = 0; i < n; i++,res++)
                cache[i,i] = true;

            //Double letter strings
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    cache[i, i + 1] = true;
                    res++;
                }
            }

            //All other strings
            for(int len = 3; len <= n; len++)
                for(int i = 0, j = i + len-1; j < n; i++, j++)
                {
                    if((s[i] == s[j]) && (cache[i + 1, j - 1]))
                    {
                        cache[i, j] = true;
                        res++;
                    }
                }

            return res;
        }
    }
}
