using System;
using System.Collections.Generic;

namespace Letter_Combinations_of_a_Phone_Number
{
    class Program
    {

        static void Main(string[] args)
        {
            PrintArray(LetterCombinations("23"));
            PrintArray(LetterCombinations(""));
            PrintArray(LetterCombinations("2"));
        }

        public static void PrintArray(IList<string> list)
        {
            foreach(string s in list)
            {
                Console.Write("[{0}] ", s);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Permutates all the possible combinations of letters pertaining to phone digits. 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static IList<string> LetterCombinations(string digits)
        {
            List<string> res = new List<string>(); //Results
            if (string.IsNullOrEmpty(digits)) return res;
            GetLetterCombos(digits, "", 0, res);
            return res;
        }

        static string[] lettersArray = { "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public static void GetLetterCombos(string digits, string cur, int idx, List<string> res)
        {
            //Base case
            if(idx >= digits.Length)
            {
                res.Add(cur);
                return;
            }

            //Grab our current digit
            int digit = int.Parse(digits[idx].ToString());

            //Grab possible letters from our current digit
            string letters = lettersArray[digit - 1];
            
            string originalCur = cur; //Original Current String

            //Permutate for each possible letter of our current digit
            foreach (char c in letters)
            {
                cur = originalCur;
                cur += c;
                //Do a recursive call
                GetLetterCombos(digits, cur, idx + 1, res);
            }
        }
    }
}
