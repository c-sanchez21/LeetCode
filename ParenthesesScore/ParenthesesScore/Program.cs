using System;

namespace ParenthesesScore
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3651/
        static void Main(string[] args)
        {
            string[] testCases = new string[] { "(())", "()()", "(()(()))", "(((())))", "((())()()((())))" };
            foreach (string s in testCases)
                Console.WriteLine(ScoreOfParentheses(s));
        }

        public static int ScoreOfParentheses(string S)
        {
            int result = 0;
            for (int i = 0; i < S.Length; i++)
                result += ScoreOfParentheses(S, ref i);
            return result;
        }

        public static int ScoreOfParentheses(string S, ref int i)
        {
            bool open = false;
            int sum = 0;
            for (; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case '(':
                        if (!open)
                            open = true;
                        else sum = sum + ScoreOfParentheses(S, ref i); //Inner parentheses - use recursion
                        break;
                    case ')':
                        if (sum > 0)
                            return sum * 2; // Case: (A+B)*2;
                        else return 1; //Case: ()
                }
            }
            return 0;
        }

    }
}
