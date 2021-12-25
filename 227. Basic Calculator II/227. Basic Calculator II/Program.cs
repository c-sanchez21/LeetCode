using System;
using System.Collections.Generic;
using System.Text;

namespace _227._Basic_Calculator_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate("3+2*2"));
            Console.WriteLine(Calculate(" 3/2 "));
            Console.WriteLine(Calculate(" 3+5 / 2"));
        }

        public static int Calculate(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;

            int curNum = 0;
            Stack<int> stack = new Stack<int>(); //Stores all numbers to add
            char c;
            int length = s.Length; //String length
            char op ='+'; //Operation

            //Iterate thru string
            for(int i = 0; i < length; i++)
            {
                c = s[i]; //Current Character 

                //If it's a digit append it to our current number
                if (Char.IsDigit(c))
                    curNum = (curNum * 10) + (int)char.GetNumericValue(c);
                
                //If non digit and non whitespace - or not end of string
                //Then perform Operation per precedence rules 
                if (!Char.IsDigit(c) && c != ' ' || i == length-1)
                {
                    if(op == '-')
                        stack.Push(curNum * -1);
                    if (op == '+')
                        stack.Push(curNum);
                    if (op == '/')
                        stack.Push(stack.Pop() / curNum);
                    if (op == '*')
                        stack.Push(stack.Pop() * curNum);
                    op = c;
                    curNum = 0;
                }
            }

            //Add the numbers stored in the stack
            int result = 0;
            while (stack.Count > 0)
                result += stack.Pop();
            return result; //Return result
        }
    }
}
