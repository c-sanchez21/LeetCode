using System;

namespace _462._Minimum_Moves_to_Equal_Array_Elements_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinMoves2(new int[] { 1, 2, 3 }));
            Console.WriteLine(MinMoves2(new int[] { 1, 10, 2, 9 }));
            Console.WriteLine(MinMoves2(new int[] { 1}));
            Console.WriteLine(MinMoves2(new int[] { 1, 0, 0, 8, 6 }));//14
        }

        public static int MinMoves2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            long min = int.MaxValue;
            long sum;
            foreach(int num in nums)
            {
                sum = 0;
                foreach(int n in nums)
                    sum += Math.Abs(num - n);
                min = Math.Min(sum, min);
            }
            return (int)min;
        }
    }
}
