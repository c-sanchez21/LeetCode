using System;
using System.Collections.Generic;

namespace _1291._Sequential_Digits
{
    class Program
    {
        //https://leetcode.com/problems/sequential-digits/
        static void Main(string[] args)
        {
            Console.WriteLine("Exmaple 1:");
            foreach (int num in SequentialDigits(100, 300))
                Console.WriteLine(num.ToString());

            Console.WriteLine();

            Console.WriteLine("Example 2:");
            foreach (int num in SequentialDigits(1000, 13000))
                Console.WriteLine(num);
           
        }

        public static IList<int> SequentialDigits(int low, int high)
        {
            IList<int> results = new List<int>();
            string numbers = "123456789";

            //Length of Numbers / Number of digits 
            int min = low.ToString().Length;
            int max = high.ToString().Length;

            //Grab all the Sequential digit strings from length min to max
            int num;
            for(int i = min; i < max+1;i++)//From length of low to length of high
            {
                for(int start = 0; start < 10-i; ++start)
                {
                    num = int.Parse(numbers.Substring(start, i));
                    //Add numbers that are in [low,high] 
                    if (num >= low && num <= high) results.Add(num);
                }
            }
            return results;
        }
    }
}
