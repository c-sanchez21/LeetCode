using System;
using System.Collections.Generic;

namespace _946._Validate_Stack_Sequences
{
    class Program
    {
        //https://leetcode.com/problems/validate-stack-sequences/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 },
                new int[] { 4, 5, 3, 2, 1 }));

            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 },
          new int[] { 4, 3,5, 1, 2 }));

        }

        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int idx = 0; //Index
            Stack<int> stack = new Stack<int>(); //Stack to hold pushed
            for(int i =0; i < pushed.Length; i++)
            {
                stack.Push(pushed[i]);
                //If stack contains the next number to be popped then pop
                while(stack.Count > 0 && popped[idx] == stack.Peek())
                {
                    stack.Pop();
                    idx++;
                }
            }
            return stack.Count == 0; //Returns true if possible. 
        }
    }
}
