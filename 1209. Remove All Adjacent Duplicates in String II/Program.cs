using System;

namespace _1209._Remove_All_Adjacent_Duplicates_in_String_II
{
    class Program
    {
        //https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveDuplicates("deeedbbcccbdaa", 3));
            Console.WriteLine(RemoveDuplicates("pbbcggttciiippooaais", 2));
        }

        //Remove duplicate adjacent chars of size k in the string
        public static string RemoveDuplicates(string s, int k)
        {
            if (k > s.Length) return s;
            if (k == 1) return "";

            //Use memoization
            int[] counts = new int[s.Length];

            //Iterate thru the string
            for (int i = 0; i < s.Length; i++)
            {
                //If chars don't match or at index 0
                if (i == 0 || s[i] != s[i - 1])
                    counts[i] = 1;
                else //Char match
                {
                    counts[i] = counts[i - 1] + 1;//Increment count
                    if (counts[i] == k)//if we have k duplicates
                    {//Remove from string
                        s = s.Remove(i - k + 1, k);
                        i = i - k;
                    }
                }
            }
            return s;
        }
    }
}
