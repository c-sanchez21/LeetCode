using System;

namespace _258._Add_Digits
{
    class Program
    {
        //https://leetcode.com/problems/add-digits/
        static void Main(string[] args)
        {
            //Upper and Lower bound for our tests
            int min = 1;
            int max = 100;

            //Examples
            for (int i = min; i <= max; i++)
                Console.Write("{1}=>{0} ", AddDigits(i),i);

            Console.WriteLine("\n\n");

            for (int i = min; i <= max; i++)
                Console.Write("{0}=>{1} ", i, AddDigits2(i));

            Console.WriteLine();
        }

        public static int AddDigits(int num)
        {
            //Base case
            if (num <= 0) return 0;

            //After examing the series 1,2,3,4,5,6,7,8,9,1,...1
            //The series is a mod of 9
            if (num % 9 == 0) return 9;
            return num % 9; 
        }
        
        [Obsolete]
        public static int AddDigits2(int num)
        {
            //Base case;
            if (num < 10) return num;

            //Convert the number to a string and
            //add up the digits until less than 10
            string s; 
            while(num > 9)
            {
                s = num.ToString();
                num = 0;

                //Add up each digit 
                for (int i = 0; i < s.Length; i++)
                    num += (int)char.GetNumericValue(s[i]);
            }
            return num;
        }
    }
}
