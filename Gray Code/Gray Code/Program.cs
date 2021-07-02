using System;
using System.Collections.Generic;


namespace Gray_Code
{
    //https://leetcode.com/explore/featured/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3799/
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int num in GrayCode(3))
                Console.Write(" {0} ", num);

        }
        public static IList<int> GrayCode(int n)
        {
            List<int> res = new List<int>();
            HelperFunction(res, n);
            return res;
        }


        private static void HelperFunction(List<int> res, int n)
        {
            //Base case
            if (n == 0)
            {
                res.Add(0);
                return;
            }

            //derive the n bits sequence from the (n - 1) bits sequence.
            HelperFunction(res, n - 1);
            int currentSequenceLength = res.Count;

            // Set the bit at position n - 1 (0 indexed) and assign it to mask.
            int mask = 1 << (n - 1);
            for (int i = currentSequenceLength - 1; i >= 0; i--)
            {
                // mask is used to set the (n - 1)th bit from the LSB of all the numbers present in the current sequence.
                res.Add(res[i] | mask);
            }
        }
    }
}
