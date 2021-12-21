using System;

namespace _231._Power_of_Two
{
    class Program
    {
        //https://leetcode.com/problems/power-of-two/
        static void Main(string[] args)
        {
            //Print out powers of 2
            for (int i = 0; i < 1025; i++)
                if (IsPowerOfTwo(i))
                    Console.WriteLine("{0} is a power of 2", i);

            //Negative numbers should not be a power of 2
            for (int i = 0; i > -1025; i--)
                if (IsPowerOfTwo(i))
                    Console.WriteLine("{0} is a power of 2", i);
        }

        public static bool IsPowerOfTwo(int n)
        {
            //Check all possible powers of 2
            int pow = 1; //0000...0001
            //2^31-1 = 2,147,483,647 = 0111 1111 1111 1111 1111 1111 1111 1111
            //-2^32 = -2,147,483,648 = 1000 0000 0000 0000 0000 0000 0000 0000
            //So we only need to shift left 30 times
            for (int i = 0; i < 31; i++)
            {
                if (pow == n) return true; //Return true if match
                pow = pow << 1; //Shift bit to left by 1
            }

            //Is not a power of 2
            return false;
        }

        //Two's complement method
        public static bool IsPowerOfTwo2(int n)
        {
            if (n == 0) return false;
            long x = (long)n;
            //Because of Two's complement 
            //-x = ~x + 1 - all bits inverted except the right most
            return (x & (-x)) == x;
        }
    }
}
