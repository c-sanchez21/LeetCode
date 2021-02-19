using System;

namespace ArithmeticSlices
{
    class Program
    {
        //Problem: https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3644/
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 2, 3, 5, 7}));
        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            if (A == null || A.Length < 3) return 0;
            int diff = 0;
            int count = 0;
            int result = 0;
            for(int i = 0; i < A.Length-1; i++)
            {
                diff = A[i + 1] - A[i];
                while (i+2 < A.Length && (A[i+2] == (A[i+1] + diff)))
                {
                    count++;
                    i++;
                }
                if(count > 0)
                {
                    result += (count * (count + 1)) / 2;
                    count = 0;
                }      
            }
            return result;
        }
    }
}
