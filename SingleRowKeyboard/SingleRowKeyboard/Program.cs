using System;
using System.Collections.Generic;

namespace SingleRowKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3656/
            string[][] inputs = new string[][] { new string[] { "abcdefghijklmnopqrstuvwxyz", "cba" }, new string[] { "pqrstuvwxyzabcdefghijklmno","leetcode" } };
            foreach (string[] input in inputs)
                Console.WriteLine(CalculateTime(input[0], input[1]));
        }

        public static int CalculateTime(string keyboard, string word)
        {
            Dictionary<char, int> keyMap = new Dictionary<char, int>();
            for(int i =0; i < keyboard.Length; i++)
                keyMap.Add(keyboard[i], i);

            int prev = 0;
            int next;
            int result = 0;
            foreach(char c in word)
            {
                next = keyMap[c];
                result += Math.Abs(next - prev);
                prev = next;
            }
            return result;
        }
    }
}
