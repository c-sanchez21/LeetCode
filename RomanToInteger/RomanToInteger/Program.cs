using System;

namespace RomanToInteger
{
    //https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3646/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("IV"));
            Console.WriteLine(RomanToInt("IX"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }

        public static int RomanToInt(string s)
        {
            int j;
            int result = 0;
            int val = 0;
            int val2 = 0;
            for(int i = 0; i < s.Length; i++)
            {
                j = i + 1;
                val = RomanValue(s[i]);
                val2 = 0;
                if (j < s.Length)
                    val2 = RomanValue(s[j]);
                if (val2 > val)
                {
                    val = (val2 - val);
                    i++;
                }
                result += val;
            }
            return result;
        }

        public static int RomanValue(char c)
        {
            switch (c)
            {
                case 'M':
                    return 1000;
                case 'D':
                    return 500;
                case 'C':
                    return 100;
                case 'L':
                    return 50;
                case 'X':
                    return 10;
                case 'V':
                    return 5;
                case 'I':
                    return 1;
            }
            return 0;
        }
    }
}
