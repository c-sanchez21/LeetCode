using System;

namespace _389._Find_the_Difference
{
    class Program
    {
        //https://leetcode.com/problems/find-the-difference/
        static void Main(string[] args)
        {
            //Example 1:
            Console.WriteLine(FindTheDifference("abcd", "abcde"));

            //Example 2: 
            Console.WriteLine(FindTheDifference("", "y"));
        }

        public static char FindTheDifference(string s, string t)
        {
            char c = (char)0; //Initialize to zero
            foreach (char ch in s) //XOR all elements of s
                c ^= ch;
            foreach (char ch in t) //XOR all elements of t
                c ^= ch;
            return c; //Remaining value is the difference. 
        }
    }
}
