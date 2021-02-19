using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumRemoveParentheses
{
    //https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3645/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinRemoveToMakeValid("lee(t(c)o)de)"));
        }

        public static string MinRemoveToMakeValid(string s)
        {
            Stack<int> indexes = new Stack<int>();
            StringBuilder sb = new StringBuilder(s);
            char c;
            for(int i = 0; i < sb.Length; i++)
            {
                c = sb[i];
                switch (c)
                {
                    case '(':
                        indexes.Push(i);
                        break;
                    case ')':
                        if (indexes.Count > 0)
                            indexes.Pop();
                        else
                        {//Unbalanced closed parenthesis detected - Remove
                            sb.Remove(i, 1);
                            i--;
                        }
                        break;
                }
            }

            while (indexes.Count > 0) //Remove left over open parenthesis
                sb.Remove(indexes.Pop(), 1);
            return sb.ToString();
        }
    }
}
