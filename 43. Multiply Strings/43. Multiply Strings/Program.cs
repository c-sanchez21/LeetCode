using System;
using System.Text;

namespace _43._Multiply_Strings
{
    class Program
    {
        //https://leetcode.com/problems/multiply-strings/
        static void Main(string[] args)
        {
            Console.WriteLine(Multiply("2", "3"));
            Console.WriteLine(Multiply("123", "456"));
            Console.WriteLine(Multiply("111", "3"));
            Console.WriteLine(Multiply("3", "333"));
            Console.WriteLine(Multiply("99", "99"));
            Console.WriteLine(Multiply("999", "999"));
        }

        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            int len1 = num1.Length;
            int len2 = num2.Length;
            int len = len1 + len2;
            int[] product = new int[len];
            for (int i = len1 - 1; i >= 0; i--)
            {
                int digit1 = (int)Char.GetNumericValue(num1[i]);
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int digit2 = (int)Char.GetNumericValue(num2[j]);
                    int idx = i + j + 1;
                    int mult = digit1 * digit2 + product[idx];
                    product[idx] = mult % 10;
                    product[idx - 1] += mult / 10;
                }
            }

            int start = product[0] != 0 ? 0 : 1;
            StringBuilder result = new StringBuilder();
            for (int i = start; i < len; i++)
                result.Append(product[i]);
            return result.ToString();
        }
    }
}
