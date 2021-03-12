using System;
using System.Collections.Generic;

namespace ContainsAllBinaryCodes
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3669/
        //https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/solution/
        static void Main(string[] args)
        {
            string[] inputs = new string[] { "00110110", "00110", "0110", "0110", "0000000001011100" };
            int[] inputs2 = new int[] { 2, 2, 1, 2, 4 };
            int max = Math.Min(inputs.Length, inputs2.Length);
            for (int i = 0; i < max; i++)
                Console.WriteLine(HasAllCodes(inputs[i], inputs2[i]));
        }

        public static bool HasAllCodes(string s, int k)
        {
            if (String.IsNullOrEmpty(s) || s.Length < k) return false;
           
            HashSet<string> codes = new HashSet<string>();
            int needed = 1 << k;
            string code;
            for(int i =k; i <= s.Length; i++)
            {
                code = s.Substring(i - k, k);
                if (!codes.Contains(code))
                {
                    codes.Add(code);
                    needed--;
                    if (needed == 0) return true;
                }
            }
            return false;
        }

        public static void GetCodes(string code, int k, HashSet<string> codes)
        {
            if (code.Length == k)
            {
                codes.Add(code);
                return;
            }
            GetCodes(code + "0", k, codes);
            GetCodes(code + "1", k, codes);
        }
    }
}
