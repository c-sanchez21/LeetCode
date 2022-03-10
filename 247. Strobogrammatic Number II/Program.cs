using System;
using System.Collections.Generic;
using System.Text;

namespace _247._Strobogrammatic_Number_II
{
    class Program
    {
        //https://leetcode.com/problems/strobogrammatic-number-ii/
        static void Main(string[] args)
        {
            //Example
            for (int i = 1; i <= 4; i++)
            {
                Console.Write("n = {0} => ",i);
                Console.Write(String.Join(" ", FindStrobogrammatic(i)));
                Console.WriteLine("\n");
            }
        }

        //Strobo Pairs that can be swapped
        static char[][] stroboPairs = new char[][] { new char[] { '0', '0' }, new char[] { '1', '1' },
        new char[] {'6','9' }, new char[]{'8','8' },new char[] {'9','6' } };

        public static IList<string> FindStrobogrammatic(int n)
        {
            //Begin recursion to generate strobo numbers 
            return GenerateStrobo(n, n);
        }
        public static List<string> GenerateStrobo(int n, int fin)
        {
            if (n == 0)
                return new List<string>(new string[] { "" });
            if (n == 1)
                return new List<string>(new string[] { "0", "1", "8" });

            List<string> prev = GenerateStrobo(n - 2, fin);

            List<string> cur = new List<string>();
            foreach (string s in prev)
                foreach (char[] pair in stroboPairs)
                    if (pair[0] != '0' || n != fin) //0...0 is not a valid number (i.e leading zero)
                        cur.Add(pair[0] + s + pair[1]);

            return cur;
        }

        //Brute Force - Times out
        public static char[] StroboChar = new char[] { '0', '1', '8', '6', '9' };
        public static Dictionary<char, int> map = new Dictionary<char, int>();
        public static IList<string> FindStrobogrammaticBruteForce(int n)
        {
            map = new Dictionary<char, int>();
            for (int i = 0; i < StroboChar.Length; i++)
                map.Add(StroboChar[i], i);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
                sb.Append('0');

            bool run = true;
            List<string> results = new List<string>();
            while (run)
            {
                if (IsStrobogrammatic(sb.ToString()))
                    results.Add(sb.ToString());
                run = Increment(sb, n - 1);
            }
            return results;
        }
        public static bool Increment(StringBuilder s, int idx)
        {
            if (idx < 0)
                return false;
            if(s[idx] == '9')
            {
                s[idx] = '0';
                return Increment(s, idx - 1);
            }
            s[idx] = StroboChar[map[s[idx]] + 1];
            return true;
        }
        public static bool IsStrobogrammatic(string num)
        {
            StringBuilder flipped = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
            {
                switch (num[i])
                {
                    case '1':
                    case '0':
                    case '8':
                        flipped.Append(num[i]);
                        break;
                    case '6':
                    case '9':
                        flipped.Append(num[i] == '6' ? "9" : "6");
                        break;
                    default:
                        return false;
                }
            }
            return flipped.ToString().CompareTo(num) == 0;
        }
    }
}
