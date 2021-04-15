using System;

namespace Fibonacci_Number
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3709/
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(2));
            Console.WriteLine(Fib(3));
            Console.WriteLine(Fib(4));
            Console.WriteLine(Fib(5));
            Console.WriteLine(Fib(6));
            Console.WriteLine(Fib(7));
            Console.WriteLine(Fib(8));
            Console.WriteLine(Fib(30));
        }

        //Calculates the Fibonacci Sequence - Recursive
        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
