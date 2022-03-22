using System;
using System.Text;

namespace _1663._Smallest_String_With_A_Given_Numeric_Value
{
    //https://leetcode.com/problems/smallest-string-with-a-given-numeric-value/
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for (int i = 1; i <= 26; i++)
                Console.WriteLine((char)('`' + i));
            */
            Console.WriteLine(GetSmallestString(3, 27)); //aay
            Console.WriteLine(GetSmallestString(5, 73)); //aaszz
            Console.WriteLine(GetSmallestString(85, 2159)); //aaszz
            Console.WriteLine(GetSmallestString(5, 73));//aaszz
        }

        public static string GetSmallestString(int n, int k)
        {
            int[] a = new int[n];
            int val = k / n;
            for (int i = 0; i < a.Length; i++)
                a[i] = val;
            int r = n - 1;
            if (k % n != 0)
            {
                int mod = k % n;
                int diff;
                while(mod > 0)
                {
                    diff = Math.Min(26 - a[r], mod);
                    mod -= diff;
                    a[r] += diff;
                    if(a[r] == 26)
                        r--;
                }
            }
            int l = 0;
            while(l < r)
            {
                if (a[l] > 1 && a[r] < 26)
                {
                    a[l]--;
                    a[r]++;
                }
                else if (a[l] == 1)
                    l++;
                else r--;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
                sb.Append((char)('`' + a[i]));
            return sb.ToString();
        }
    }
}
