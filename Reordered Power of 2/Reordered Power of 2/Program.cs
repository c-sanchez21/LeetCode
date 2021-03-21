using System;
using System.Collections.Generic;

namespace Reordered_Power_of_2
{
    class Program
    {
       //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3679/
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2, 10, 16, 24, 46 };
            foreach (int n in nums)
                Console.WriteLine(ReorderedPowerOf2(n));
        }

        public static bool ReorderedPowerOf2(int N)
        {
            //Puts N and all the powers of 2 into a string
            //and checks to see if the numbers match up. 
            string Nstr = N.ToString();
            int num = 0;
            List<string> list = new List<string>();
            string s;
            
            //Converts all the powers of 2 into a string
            for(int i = 0; i <= 30; i++)
            {
                num = (int) Math.Pow(2, i);
                s = num.ToString();
                //Add them to a checklist if same length
                if (s.Length == Nstr.Length)
                    list.Add(s);
            }
            //Check the lists to see if we have a match
            for (int i = 0; i < list.Count; i++)
            {
                string str = list[i];
                foreach (char c in Nstr)
                    if (str.Contains(c))
                    {
                        int idx = str.IndexOf(c);
                        str = str.Remove(idx, 1);
                        if (str.Length == 0) return true;
                    }
            }

            //If not match found return false
            return false;
        }
    }
}
