using System;
using System.Text;

namespace StringToIntegerAtoi
{
    class Program
    {
        //https://leetcode.com/problems/string-to-integer-atoi/
        static void Main(string[] args)
        {
            string[] inputs = new string[] 
            { "42", "   -42", "4193 with words", "words and 987", "-91283472332", 
                "--21", "+-42", "+1","  0000000000012345678", "00000-42a1234", "-42a", "  -0012a42", "-13+8"};
            foreach (string input in inputs)
                Console.WriteLine("{0} = {1}",input,MyAtoi(input));
        }

        public static int MyAtoi(string s)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            bool isNeg = false;
            string numbers = "0123456789";

            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];

                if (c == ' ')
                {
                    if (sb.Length > 0)
                        break;
                    continue;
                }
                else if (c == '-')
                {
                    if (sb.Length > 0 || (i + 1 < s.Length && !numbers.Contains(s[i + 1])))
                        break;//Invalid negative sign
                    else isNeg = true;
                }
                else if (c == '+')
                {
                    if (sb.Length > 0 || ( i + 1 < s.Length && !numbers.Contains(s[i + 1])))
                        break;//Invalid positive sign
                    else continue;
                }
                else if (numbers.Contains(c))//Append Numbers;
                    sb.Append(c);
                else break;//Invalid char
                   
            }

            int upperBound = 2147483647;
            int lowerBound = -2147483648;
            while (sb.Length > 0 && sb[0] == '0')
                sb.Remove(0, 1); //Remove leading zeroes
                
            if (sb.Length > 10)
                return isNeg ? lowerBound : upperBound;
            long result = sb.Length > 0 ? long.Parse(sb.ToString()) : 0;
            if (isNeg) result *= -1;
            if (result > upperBound) return upperBound;
            if (result < lowerBound) return lowerBound;
            return (int)result;
        }
    }
}
