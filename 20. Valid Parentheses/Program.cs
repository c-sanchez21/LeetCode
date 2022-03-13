using System;
using System.Collections.Generic;

namespace _20._Valid_Parentheses
{
    //https://leetcode.com/problems/valid-parentheses/
    class Program
    {
        static void Main(string[] args)
        {
            //Example
            string[] inputs = { "()", "()[]{}", "(]", "([)]", "{[]}", "]" };
            foreach (string input in inputs)
                Console.WriteLine("{0} is valid = {1}", input, IsValid(input));
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> map = new Dictionary<char, char>();

            //Map opening parentheses to their respective closing parentheses
            map.Add(')', '(');
            map.Add('}', '{');
            map.Add(']', '[');

            //Iterate thru the string and determing if IsValid
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if (stack.Count == 0 || stack.Peek() != map[c])
                            return false;
                        else stack.Pop();
                        break;
                }
            }
            return stack.Count == 0;
        }
    }
}
