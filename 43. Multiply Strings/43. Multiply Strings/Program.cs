using System;
using System.Text;

namespace _43._Multiply_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(Multiply("2", "3"));
            Console.WriteLine(Multiply("123", "456"));
            Console.WriteLine(Multiply("111", "3"));
            Console.WriteLine(Multiply("3", "333"));
            */
            Console.WriteLine(Multiply("99", "99"));
        }

        //TODO: Currently Fails for "99" x "99" 
        public static string Multiply(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || String.IsNullOrEmpty(num2)) return null;
            if (num1 == "0" || num2 == "0") return "0";

            string top = Reverse(num1);
            string bot = Reverse(num2);
            StringBuilder ans = new StringBuilder("");
            for (int i = 0; i < top.Length + bot.Length; i++)
                ans.Append("0");
            int idx;//Index - Cur position in the answer
                   
            int digit1, digit2; 
            for(int i = 0; i < top.Length; i++)
            {
                digit1 = (int) char.GetNumericValue(top[i]);
                for (int j = 0; j < bot.Length; j++)
                {
                    digit2 = (int)char.GetNumericValue(bot[j]);

                    idx = i + j;
                    int carry = (int)Char.GetNumericValue(ans[idx]);
                    int mult = digit1 * digit2 + carry;
                    ans[idx] = (mult % 10).ToString()[0];
                    int val = (int)Char.GetNumericValue(ans[idx + 1]);
                    val += mult / 10;                    
                    ans[idx + 1] = val.ToString()[0];
                }
            }

            //Remove leading zeroes
            while (ans[ans.Length - 1] == '0')
                ans.Remove(ans.Length - 1, 1);

            return Reverse(ans.ToString());
        }

        public static string Reverse(string s)
        {
            char[] cArray = s.ToCharArray();
            Array.Reverse(cArray);
            string rev = new string(cArray);
            return rev;
        }
    }
}
