using System;

namespace _868._Binary_Gap
{
    class Program
    {
        //https://leetcode.com/problems/binary-gap/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(BinaryGap(22));
            Console.WriteLine(BinaryGap(8));
            Console.WriteLine(BinaryGap(5));
        }

        public static int BinaryGap(int n)
        {
            if (n == 0) return 0;

            int gap = 0;
            int cur = -1;
            while(n > 0)
            {
                if ((n & 1) == 1)
                {
                    gap = Math.Max(gap, cur);
                    cur = 1;
                }
                else if(cur != -1) cur++;
                n  = n >> 1;
            }
            return gap;

        }
    }
}
