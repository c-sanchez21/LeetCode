using System;
using System.Collections.Generic;
using System.Text;

namespace _6._Zigzag_Conversion
{
    internal class Program
    {
        //https://leetcode.com/problems/zigzag-conversion/description/
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 3));
            Console.WriteLine(Convert("PAYPALISHIRING", 4));
            Console.WriteLine(Convert("A", 1));
        }

        public static string Convert(string s, int numRows)
        {

            if (numRows == 1) return s;

            //Generate new list/matrix
            List<List<char>> chars= new List<List<char>>();
            for(int i = 0; i < numRows; i++)
                chars.Add(new List<char>());

            int row, idx;
            idx = 0;
            char c;
            row = 0;

            //Add characters to the Matrix/Lists
            while (idx < s.Length)
            {
                while(idx < s.Length && row < numRows)
                {
                    c = s[idx];
                    chars[row].Add(c);
                    row++;
                    idx++;
                }
                row = numRows - 2;
                while(idx < s.Length && row >= 0)
                {
                    c = s[idx];
                    chars[row].Add(c);
                    row--;
                    idx++;
                }
                row = 1;
            }

            //Concate the chars into new string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numRows; i++)
                foreach (char x in chars[i])
                    sb.Append(x);
            return sb.ToString();
        }
    }
}
