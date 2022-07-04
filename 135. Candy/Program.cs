using System;

namespace _135._Candy
{
    internal class Program
    {
        //https://leetcode.com/problems/candy/
        static void Main(string[] args)
        {
            Console.WriteLine(Candy(new int[] { 1, 0, 2 }));
            Console.WriteLine(Candy(new int[] { 1, 2, 2 }));
        }

        public static int Candy(int[] ratings)
        {
            int sum = 0;
            int n = ratings.Length;
            int[] l2r = new int[n];
            int[] r2l = new int[n];
            Array.Fill<int>(l2r, 1);
            Array.Fill<int>(r2l, 1);
            for(int i = 1; i < n; i++)
                if (ratings[i] > ratings[i - 1])
                    l2r[i] = l2r[i - 1] + 1;
            
            for(int i = n-2; i >=0; i--)
                if (ratings[i] > ratings[i + 1])
                    r2l[i] = r2l[i + 1] + 1;
            
            for (int i = 0; i < ratings.Length; i++)
                sum += Math.Max(l2r[i], r2l[i]);
            return sum;
        }
    }
}
