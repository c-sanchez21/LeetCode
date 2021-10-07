using System;

namespace _70._Climbing_Stairs
{
    class Program
    {
        //https://leetcode.com/problems/climbing-stairs/
        static void Main(string[] args)
        {
            for (int i = 0; i <= 45; i++)
                Console.WriteLine(ClimbStairs(i));
            Console.WriteLine("FIN!");
        }

        public static int ClimbStairs(int n)
        {
            //n is bound by: 0 <= n <= 45
            //Pre calculate values for n
            int[] A = new int[46];
            A[1] = 1;
            A[2] = 2;
            for (int i = 3; i <= 45; i++)
                A[i] = A[i - 2] + A[i - 1];

            return A[n];
        }

        public static int ClimbStairsRecursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return ClimbStairs(n - 2) + ClimbStairs(n - 1);
        }
    }
}
