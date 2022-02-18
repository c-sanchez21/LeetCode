using System;
using System.Text;

namespace _402._Remove_K_Digits
{
    class Program
    {
        //https://leetcode.com/problems/remove-k-digits/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(RemoveKdigits("120", 2));
            Console.WriteLine(RemoveKdigits("1432219", 3));
            Console.WriteLine(RemoveKdigits("10200", 1));
            Console.WriteLine(RemoveKdigits("10", 2));
            Console.WriteLine(RemoveKdigits("0", 2));
            Console.WriteLine(RemoveKdigits("123456789", 2));
            Console.WriteLine(RemoveKdigits("9876789", 4));
            Console.WriteLine(RemoveKdigits("2413", 2));
            Console.WriteLine(RemoveKdigits("1234567890", 9)); //0
        }

        public static string RemoveKdigits(string num, int k)
        {
            //Check for invalid input
            if (string.IsNullOrEmpty(num)) return "0";

            //Check case where all numbers need to be removed
            if (num.Length <= k ) return "0";

            //Variables 
            int toRemove = k;
            StringBuilder sb = new StringBuilder(num);
            int i = 0; //Index
            int a, b; //Digits a And b

            //While digits to remove is greater than zero and index is not out of bounds
            while (i < sb.Length - 1 && toRemove > 0)
            {
                //While a (left) is greater than digit b (right) then remove left
                a = (int)sb[i];
                b = (int)sb[i + 1]; //Note: a b are being converted to Ascii values but still works for digits
                if (a > b)
                {
                    sb.Remove(i, 1); //Remove left digit
                    toRemove--; //Decrement to remove counter
                    if (i > 0) i--; //Decrement index
                }
                else i++; 
            }

            //If digits to remove > 0 then remove right most digit
            while(toRemove > 0)
            {
                sb.Remove(sb.Length-1, 1);
                toRemove--;
            }

            //Remove Leading Zeroes
            while (sb.Length > 1 && sb[0] == '0')
                sb.Remove(0, 1);

            //Return results
            return sb.ToString();
        }
    }
}
