using System;

namespace Determine_if_String_Halves_Are_Alike
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3699/
        static void Main(string[] args)
        {
            string[] input = { "book", "textbook", "MerryChristmas", "AbCdEfGh" };
            foreach(string s in input)
            {
                Console.WriteLine("[{0}] halves are alike? = {1}", s, HalvesAreAlike(s));
            }
        }

        public static bool HalvesAreAlike(string s)
        {
            //Halves are alike if they both have the same amount of vowels
            int mid = s.Length / 2;
            int vowelCount1 = VowelCount(s.Substring(0, mid));
            int vowelCount2 = VowelCount(s.Substring(mid));
            return vowelCount1 == vowelCount2;
        }

        public static int VowelCount(string s)
        {
            int count = 0;
            s = s.ToUpper();
            foreach(char c in s)
            {
                switch(c)
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        count++;
                        break;
                }
            }
            return count;            
        }
    }
}
