using System;

namespace _165._Compare_Version_Numbers
{
    class Program
    {
        //https://leetcode.com/problems/compare-version-numbers/
        static void Main(string[] args)
        {
            //Examples 
            Console.WriteLine(CompareVersion("0.1", "1.1"));
            Console.WriteLine(CompareVersion("1.0.1", "1"));
            Console.WriteLine(CompareVersion("7.5.2.4", "7.5.3"));
            Console.WriteLine(CompareVersion("1.01", "1.001"));
            Console.WriteLine(CompareVersion("1.0", "1.0.0"));
        }

        public static int CompareVersion(string version1, string version2)
        {
            //Split strings by the '.' delimiter
            string[] s1 = version1.Split(".");
            string[] s2 = version2.Split(".");

            //Get the longer length of both strings
            int max = s1.Length > s2.Length ? s1.Length : s2.Length;

            //Iterate thru each number seperated by '.' 
            string vs1, vs2;
            int v1, v2;
            for (int i = 0; i < max; i++)
            {
                //Assign null if no more numbers
                vs1 = i > s1.Length - 1 ? null : s1[i];
                vs2 = i > s2.Length - 1 ? null : s2[i];

                //Parse the number ignoring leading zeroes, or default 0 if null
                v1 = vs1 == null ? 0 : int.Parse(vs1);
                v2 = vs2 == null ? 0 : int.Parse(vs2);

                //Compare Version1 with Version2 and return comparison value if not equal
                if (v1 > v2) return 1;
                if (v1 < v2) return -1;
            }
            return 0; //Return 0 if equal
        }
    }
}
