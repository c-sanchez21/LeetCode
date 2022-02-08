using System;
using System.Collections.Generic;

namespace _1221._Split_a_String_in_Balanced_Strings
{
    class Program
    {
        //https://leetcode.com/problems/split-a-string-in-balanced-strings/
        static void Main(string[] args)
        {
            //Exmaple
            string s = "RLRRLLRLRL";
            int ans = BalancedStringSplit(s);
            Console.WriteLine("The result is: {0}", ans);
        }

        //Balanced strings are those that have an equal quantity of 'L' and 'R' characters.
        //Given a balanced string s, split it in the maximum amount of balanced strings.
        //Returns the maximum amount of split balanced strings.
        public static int BalancedStringSplit(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;

            //Utilize a stack to find matching L & R chars
            Stack<char> stack = new Stack<char>();
            int count = 0;
            stack.Push(s[0]); //Push first char into stack
            for (int i = 1; i < s.Length; i++)
            {
                if (stack.Count > 0)
                {
                    //If matching L & R chars found
                    if ((s[i] == 'L' && stack.Peek() == 'R')
                        || (s[i] == 'R' && stack.Peek() == 'L'))
                    {
                        stack.Pop();//Pop top of the stack
                        if (stack.Count == 0) //If stack is emtpy then matching set found
                            count++; //Increment count
                        continue;
                    }
                }
                stack.Push(s[i]); //Push char into stack
            }
            return count; //Return count 
        }
    }
}
