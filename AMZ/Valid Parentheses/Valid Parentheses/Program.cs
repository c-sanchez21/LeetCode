using System;
using System.Collections.Generic;

namespace Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = { "()", "()[]{}", "(]", "([)]", "{[]}", "]" };
            foreach (string input in inputs)
                Console.WriteLine("{0} is valid = {1}", input, IsValid(input));
        }

        public static bool IsValid(string s)
        {
            Dictionary<char, char> cMap = new Dictionary<char, char>();
            cMap.Add(')', '(');
            cMap.Add('}', '{');
            cMap.Add(']', '[');
            Stack<char> stack = new Stack<char>();
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
                        if (stack.Count == 0 || stack.Peek() != cMap[c])
                            return false;
                        else stack.Pop();
                        break;
                }
            }
            return stack.Count == 0;
        }
    }
}
