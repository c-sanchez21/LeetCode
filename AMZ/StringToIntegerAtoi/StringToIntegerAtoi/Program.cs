using System;
using System.Text;

namespace StringToIntegerAtoi
{
    class Program
    {
        //https://leetcode.com/problems/string-to-integer-atoi/
        static void Main(string[] args)
        {
            //Test Cases
            string[] inputs = new string[] 
            { "42", "   -42", "4193 with words", "words and 987", "-91283472332", 
                "--21", "+-42", "+1","  0000000000012345678", "00000-42a1234", "-42a", "  -0012a42", "-13+8"};

            //Test Each Case
            foreach (string input in inputs)
                Console.WriteLine("{0} = {1}",input,MyAtoi(input));
        }

        public static int MyAtoi(string s)
        {
            //Setup our variables 
            StringBuilder sb = new StringBuilder();
            char c;
            bool isNeg = false;
            string numbers = "0123456789"; //Lookup Numbers

            //Examine each character 
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];

                //Skip any pre-fix whitespace
                if (c == ' ')
                {
                    if (sb.Length > 0)
                        break;
                    continue;
                }
                //Check for Negative sign
                else if (c == '-')
                {
                    if (sb.Length > 0 || (i + 1 < s.Length && !numbers.Contains(s[i + 1])))
                        break;//Invalid negative sign
                    else isNeg = true;
                }
                //Check for positive sign
                else if (c == '+')
                {
                    if (sb.Length > 0 || ( i + 1 < s.Length && !numbers.Contains(s[i + 1])))
                        break;//Invalid positive sign
                    else continue;
                }
                //Check if it's a number
                else if (numbers.Contains(c))//Append Numbers;
                    sb.Append(c);
                else break;//Invalid char
            }

            //Upper and lower bounds 
            int upperBound = 2147483647;
            int lowerBound = -2147483648;

            //Remove leading zeroes
            while (sb.Length > 0 && sb[0] == '0')
                sb.Remove(0, 1); 
                
            //If Number length exceeds bound return respective bound
            if (sb.Length > 10)
                return isNeg ? lowerBound : upperBound;

            //Parse the value and return result value 
            long result = sb.Length > 0 ? long.Parse(sb.ToString()) : 0;
            if (isNeg) result *= -1;
            if (result > upperBound) return upperBound;
            if (result < lowerBound) return lowerBound;
            return (int)result;
        }
    }
}
