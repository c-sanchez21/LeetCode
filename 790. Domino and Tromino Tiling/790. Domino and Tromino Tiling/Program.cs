using System;

namespace _790._Domino_and_Tromino_Tiling
{
    //https://leetcode.com/problems/domino-and-tromino-tiling/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumTilings(3));
            Console.WriteLine(NumTilings(1));
            Console.WriteLine(NumTilings(1000));
        }

        public static int NumTilings(int n)
        {
            int mod = 1000000007;
            if (n <= 2) return n;

            //f[i]: Cache representing fully covered
            long[] f = new long[n + 1];

            //p[i]: Cache representing partially covered
            long[] p = new long[n + 1];

            f[1] = 1L;
            f[2] = 2L;
            p[2] = 1L;

            for(int i = 3; i < n+1; i++)
            {
                f[i] = (f[i - 1] + f[i - 2] + 2 * p[i - 1]) % mod;
                p[i] = (p[i - 1] + f[i - 2]) % mod;
            }

            return ((int)f[n]);
        }
    }
}
