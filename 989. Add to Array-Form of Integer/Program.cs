using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _989._Add_to_Array_Form_of_Integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintArray(AddToArrayForm(new int[] { 1, 2, 0, 0 }, 34));
            PrintArray(AddToArrayForm(new int[] { 2, 7, 4 }, 181));
            PrintArray(AddToArrayForm(new int[] { 2, 1, 5 }, 806));

        }

        private static void PrintArray(IList<int> list)
        {
            Console.Write("[");
            foreach (int i in list)
                Console.Write(String.Format("{0},", i));
            Console.WriteLine("]");
        }

        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            int idx = num.Length - 1;
            int cur = k;
            List<int> result = new List<int>();
            while (idx >= 0 || cur > 0)
            {
                if (idx >= 0)
                    cur += num[idx];
                result.Add(cur % 10);
                cur /= 10;
                idx--;
            }
            result.Reverse();
            return result;
        }
    }
}
