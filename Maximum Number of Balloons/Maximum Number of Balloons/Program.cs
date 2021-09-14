using System;
using System.Collections.Generic;

namespace Maximum_Number_of_Balloons
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3973/
        static void Main(string[] args)
        {
            Console.WriteLine(MaxNumberOfBalloons("loonbalxballpoon"));
        }

        public static int MaxNumberOfBalloons(string text)
        {
            //Initialize "Balloon" chars to 0
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach(char c in "balon")
                counts.Add(c, 0);
            
            //Process Input - count the "Balloon" chars
            foreach(char c in text)
            {
                switch(c)
                {
                    case 'b':
                    case 'a':
                    case 'l':
                    case 'o':
                    case 'n':
                        counts[c]++;
                        break;
                }
            }

            //Find the max times "Balloon" can be created. 
            int res = int.MaxValue;
            res = Math.Min(counts['b'], res);
            res = Math.Min(counts['a'], res);
            res = Math.Min(counts['l']/2, res);
            res = Math.Min(counts['o']/2, res);
            res = Math.Min(counts['n'], res);
            return res;
        }
    }
}
