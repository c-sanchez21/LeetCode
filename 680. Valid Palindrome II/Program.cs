using System;

namespace _680._Valid_Palindrome_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidPalindrome("aba"));
            Console.WriteLine(ValidPalindrome("abca"));
            Console.WriteLine(ValidPalindrome("abc"));
            Console.WriteLine(ValidPalindrome("a"));
            Console.WriteLine(ValidPalindrome("ab"));
            Console.WriteLine(ValidPalindrome("abcdeffedcbaa"));
            Console.WriteLine(ValidPalindrome("deeee"));
            Console.WriteLine(ValidPalindrome("cbbcc"));
        }

        public static bool ValidPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (s[l] != s[r])
                    return (IsPalindrome(s, l+1, r) || IsPalindrome(s, l, r-1));
                l++;
                r--;
            }
            return true;
        }

        public static bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
                if (s[l++] != s[r--]) return false;
            return true;
        }
    }
}
