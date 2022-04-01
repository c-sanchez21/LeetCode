using System;

namespace _344._Reverse_String
{
    class Program
    {
        //https://leetcode.com/problems/reverse-string/
        static void Main(string[] args)
        {
            char[] s1 = "Hello".ToCharArray();
            ReverseString(s1);
            Console.WriteLine(new string(s1));

            char[] s2 = "Hannah".ToCharArray();
            ReverseString(s2);
            Console.WriteLine(new string(s2));
        }

        public static void ReverseString(char[] s)
        {
            char temp;
            int n;
            n = s.Length - 1;
            for(int i = 0; i < s.Length/2; i++)
            {
                temp = s[n - i];
                s[n - i] = s[i];
                s[i] = temp;   
            }
        }
    }
}
