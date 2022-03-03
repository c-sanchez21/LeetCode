using System;

namespace _392._Is_Subsequence
{
    class Program
    {
        //https://leetcode.com/problems/is-subsequence/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(IsSubsequence("abc", "ahbgdc"));
            Console.WriteLine(IsSubsequence("axc", "ahbgdc"));
        }

        public static bool IsSubsequence(string s, string t)
        {
            //Check edge cases
            if (String.IsNullOrEmpty(s)) return true;
            if (string.IsNullOrEmpty(t)) return false;

            //Iterate thru string T and check if it contains chars from s
            for(int i = 0, j = 0 ; i < t.Length; i++)
                if(s[j] == t[i]) //Character found 
                {
                    j++; //Advance the index of string s
                    if (j == s.Length) return true; //Match found
                }
            return false;
        }
    }
}
