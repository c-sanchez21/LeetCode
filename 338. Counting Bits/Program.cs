using System;

namespace _338._Counting_Bits
{
    class Program
    {
        //https://leetcode.com/problems/counting-bits/
        static void Main(string[] args)
        {
            //Example 1
            Console.WriteLine(String.Join(' ', CountBits(2)));

            //Example 2
            Console.WriteLine(String.Join(' ', CountBits(5)));
            
        }

        public static int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];
            // x / 2 is x >> 1 and x % 2 is x & 1
            for (int x = 1; x <= n; x++)
                //x = 1 => ans[0] + (x&1) = 1;
                //x = 2 => ans[1] + (x&1) = 1;
                //x = 3 = 011 => ans[1] + (x & 1) = 2;
                //x = 4 = 100 => ans[2] + (x & 1) = 1; 
                ans[x] = ans[x >> 1] + (x & 1);
            return ans;
        }
    }
}
