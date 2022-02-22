using System;

namespace _171._Excel_Sheet_Column_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TitleToNumber("A"));
            Console.WriteLine(TitleToNumber("B"));
            Console.WriteLine(TitleToNumber("AA"));
            Console.WriteLine(TitleToNumber("ZY"));
            Console.WriteLine(TitleToNumber("ZZ"));
            Console.WriteLine(TitleToNumber("AAA"));
        }

        public static int TitleToNumber(string columnTitle)
        {
            //Check for invalid input
            if (String.IsNullOrEmpty(columnTitle)) return 0;

            //A = 1, Z = 26, AA = 27, AB = 28, ZY = 701
            char c;
            int val = 0;
            int result = 0;
            int multi = 1; //Multiplier;
            for(int i = columnTitle.Length-1; i >= 0; i--)
            {
                c = columnTitle[i];
                val = c - '@'; //A = 1, Z = 26;
                result += (val * multi);
                multi *= 26;
            }
            return result;
        }
    }
}
