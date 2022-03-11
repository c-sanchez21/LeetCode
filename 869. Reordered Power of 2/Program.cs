using System;
using System.Collections.Generic;

namespace _869._Reordered_Power_of_2
{
    class Program
    {
        //https://leetcode.com/problems/reordered-power-of-2/
        static void Main(string[] args)
        {
            /*
            for (int i = 1; i <= 31; i++)
                Console.Write(" {0} ", Math.Pow(2, i));
            */
            //Examples
            for (int i = 1; i <= 500; i++)
            {
                bool canReorder = ReorderedPowerOf2(i);
                if(canReorder)
                    Console.WriteLine("{0} => True", i);
            }
        }

        public static bool ReorderedPowerOf2(int n)
        {
            string s = n.ToString();
            List<string> pos = new List<string>(); //Possible numbers
            int power;
            string powerStr;

            //Convert the the powers of 2 into a string 
            //and put possible candidates into the list
            for(int i = 0; i <= 31; i++)
            {
                power = (int)Math.Pow(2, i);
                if (power == n) return true;
                powerStr = power.ToString();
                if (powerStr.Length == s.Length)
                    pos.Add(powerStr);
                if (powerStr.Length > s.Length) break;
            }

            //Check the possibilities to determine if number
            //can be converted to a power of 2
            foreach (string p in pos)
                if (CanReorder(s, p)) return true;
            return false;
        }

        public static bool CanReorder(string from, string to)
        {
            //Put 'to' string into a frequency map
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach(char c in to)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else map[c]++;
            }

            //Determine if the letters in 'from' match 'to'
            foreach(char c in from)
            {
                if (!map.ContainsKey(c)) return false;
                map[c]--;
                if (map[c] == 0)
                    map.Remove(c);
            }
            return map.Keys.Count == 0;
        }
    }
}
