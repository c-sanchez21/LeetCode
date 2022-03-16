using System;
using System.Collections.Generic;
using System.Text;

namespace _1249._Minimum_Remove_to_Make_Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(MinRemoveToMakeValid("lee(t(c)o)de)"));
            Console.WriteLine(MinRemoveToMakeValid("a)b(c)d"));
            Console.WriteLine(MinRemoveToMakeValid("))(("));
        }

        public static string MinRemoveToMakeValid(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> stack = new Stack<int>();
            char c;
            int idx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (c == '(')
                {
                    stack.Push(idx++);
                    sb.Append(c);
                    continue;
                }
                else if (c == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        sb.Append(c);
                        idx++;
                        continue;
                    }
                    else continue; //Skip
                }
                sb.Append(c);
                idx++;
            }
            while (stack.Count > 0)
                sb.Remove(stack.Pop(), 1);
            return sb.ToString();
        }
    }
}
