using System;

namespace _476._Number_Complement
{
    class Program
    {
        //https://leetcode.com/problems/number-complement/
        static void Main(string[] args)
        {
            Console.WriteLine("Complement of {0} is {1}.", 5, FindComplement(5));
            Console.WriteLine("Complement of {0} is {1}.", 1, FindComplement(1));
        }

        public static int FindComplement(int num)
        {
            //length of num in binary
            int n = (int)(Math.Log(num) / Math.Log(2)) + 1;
            int bitmask = (1 << n)-1; //Ex: 1000 - 1 = 111
            return bitmask ^ num;//Ex: 111 ^ 101 = 2
        }
    }
}
