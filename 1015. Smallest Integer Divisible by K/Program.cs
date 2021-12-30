using System;
using System.Collections.Generic;

namespace _1015._Smallest_Integer_Divisible_by_K
{
    class Program
    {
        //https://leetcode.com/problems/smallest-integer-divisible-by-k/
        static void Main(string[] args)
        {
            Console.WriteLine(SmallestRepunitDivByK(1));
            Console.WriteLine(SmallestRepunitDivByK(2));
            Console.WriteLine(SmallestRepunitDivByK(3));
        }
        public static int SmallestRepunitDivByK(int k)
        {
            int length = 1;//Length of N
            int mod = 1;//Remainder

            //Remainders already seen to prevent cycles. 
            HashSet<int> remainders = new HashSet<int>();

            int n;
            while(mod%k != 0) 
            {
                n = mod * 10 + 1;
                mod = n % k;
                length++;
                if (remainders.Contains(mod))
                    return -1; //Endless Cycle detected
                else
                    remainders.Add(mod);
            }
            return length;
        }
    }
}
