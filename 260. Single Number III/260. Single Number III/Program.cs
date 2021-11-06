using System;

namespace _260._Single_Number_III
{
    class Program
    {
        //https://leetcode.com/problems/single-number-iii/
        static void Main(string[] args)
        {
            Print(SingleNumber(new int[] { 1, 2, 1, 3, 2, 5 }));
            Print(SingleNumber(new int[] { -1, 0 }));
            Print(SingleNumber(new int[] { 0, 1 }));
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("[{0},{1}]", arr[0], arr[1]);
        }

        public static int[] SingleNumber(int[] nums)
        {
            //Bitmask technique
            int bmask = 0;
            
            //The diffeence between
            //two Single Numbers are preserved in the bitmask   
            foreach (int n in nums)
                bmask ^= n;

            //rightmost 1-bit diff between two Single Numbers
            int diff = bmask & (-bmask);
            
            int x = 0; //bitmask that contains only x (First Single Number)
            foreach (int n in nums)
                if ((n & diff) != 0) x ^= n;
            return new int[] { x, bmask ^ x };
        }
    }
}
